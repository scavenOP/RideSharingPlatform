import { Component, EventEmitter, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import{ ApplicationRequest } from '../models/model.applicationrequest';
import { ApiService } from '../api.service';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { NavComponent } from 'src/app/nav/nav.component';
import { TokenService } from 'src/app/app.tokenservice';
import { ConnectableObservable } from 'rxjs';


@Component({
  selector: 'app-application-request',
  templateUrl: './application-request.component.html',
  styleUrls: ['./application-request.component.scss']
})
export class ApplicationRequestComponent implements OnInit{
  applicationRequest:ApplicationRequest;
  applicationRequests:ApplicationRequest[];
  statusOptions: string[];
  isAutherised:boolean;
  userhasrole:boolean = true;
  currentuserrole:string;
  isLoading:boolean;
  

  constructor(private router: Router,private route: ActivatedRoute, private apiService: ApiService,private tokenService: TokenService){}

  ngOnInit(): void {
    this.isLoading=true;
    this.currentuserrole=this.tokenService.getRole();
    this.isAutherised=this.tokenService.getToken() != null;
    this.getPendingApplicationRequest();
    console.log(this.tokenService.getname())
    this.isLoading=false;
    this.userhasrole=this.currentuserrole=='SecurityHead';
    console.log(this.userhasrole);
    console.log(this.currentuserrole);
    this.redrr();
  
  }
  redrr(){
    if(!this.isAutherised){
      this.router.navigate(['/login'],{ queryParams: {returnUrl: '/application-request'}})
    }
  }

  selectRequest(request:ApplicationRequest){
    this.applicationRequest=request;
  }

  getPendingApplicationRequest(){
    if(this.isAutherised){
    this.apiService.getPendingApplications().subscribe(
      requests =>{
        this.applicationRequests=requests;
      },
      (error) =>{ 
        console.log(error);
        if(this.tokenService.getRole()!="SecurityHead"){
          this.userhasrole=false;
        console.log("User Not Authorized");
        }
      }
    );
  }
  }
  getApplicationByUserID(userId: number): void{
    this.apiService.getApplicationById(userId).subscribe(
      (applicationRequest: ApplicationRequest) => {
        this.applicationRequest =applicationRequest;
    //     if(this.applicationRequest.licenseNo==null){
    //       this.applicationRequest.licenseNo="";
    // this.applicationRequest.expirationDate=new Date;
    // this.applicationRequest.rta="";
    // this.applicationRequest.alowedVehicles=;
    //     }
      },
      (error:any) => {
        console.log(error);
      });
    
  }

  updateApplicationStatus():void{
    //this.applicationRequest.applicationStatus = status;
    if(this.applicationRequest.expirationDate==null){
      this.applicationRequest.licenseNo="";
      this.applicationRequest.rta="";
      this.applicationRequest.alowedVehicles="";
      this.applicationRequest.expirationDate=new Date();
    }
    this.apiService.updateApplicationStatus(this.applicationRequest).subscribe(response => {
      this.applicationRequest=null;
      this.getPendingApplicationRequest();
      console.log(response);
      this.router.navigate(['/application-request'])
    },
    (error)=>{
      console.log(error);
      if(error.status===401){
      console.log("User Not Authorized");
      }
    }

    )
  }

}
