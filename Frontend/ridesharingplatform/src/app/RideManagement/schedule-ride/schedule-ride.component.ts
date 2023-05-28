import { Component, OnInit } from '@angular/core';
import { ApiService } from '../RideApi.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { TokenService } from 'src/app/app.tokenservice';
import { FareDTO } from '../Models/model.faredto';
import { HttpClient, HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-schedule-ride',
  templateUrl: './schedule-ride.component.html',
  styleUrls: ['./schedule-ride.component.scss']
})
export class ScheduleRideComponent implements OnInit{

  distances:any[] = [];
  distance:any;
  isLoading:boolean=false;
  newride: FormGroup ;
  submitted:boolean=false;
  //fdto:FareDTO;
  Fare:string;
  private apiUrl = 'https://ridesharingapi.azurewebsites.net/api'; 
  r:string;
  selectedDistance:boolean=false;


  constructor(private http: HttpClient , private tokenservice: TokenService,private fdto:FareDTO, private formBuilder: FormBuilder,private apiService:ApiService,private tokenService:TokenService){}

  ngOnInit(): void {
    this.isLoading=true;
{
    this.apiService.getdistances().subscribe((response: any[]) => {
    
      
      this.distances = response;
      
      //console.log(this.tokenService.getToken());
      
    });

    
    }
    this.isLoading=false;
  }

  onOptionSelected(event:any){
    this.isLoading=true;
    const distanceId = event.target.value;
    this.http.get(`${this.apiUrl}/GetRegNo/${this.tokenService.getid()}`,{ responseType: 'text' })
        .subscribe(
            (response: string) => {
              // Handle the response string
              console.log("ff"+response);
              this.r= response;
              this.getfare(distanceId,this.r);
    console.log(this.Fare);
    this.isLoading=false;
    this.selectedDistance=true;
    console.log(distanceId);
    this.distance=this.distances.filter(d => d.id==distanceId);
    console.log(this.distance[0]);

              // Process the response further as needed
              this.newride= new FormGroup({
                rideFrom :new FormControl(this.distance[0].from,),
                rideTo:new FormControl(this.distance[0].to,Validators.required),
                rideStartsOn:new FormControl(new Date,Validators.required),
                rideTime:new FormControl(new Date(),Validators.required),
                vehicleRegistrationNo:new FormControl(this.r,Validators.required),
                motoristUserId:new FormControl(this.tokenService.getid(),Validators.required),
                noOfSeatsAvailable:new FormControl(Validators.required)
          
          
          
              });
            },
            
            (error) => {
              // Handle errors
              console.error(error);
              return "";
            },
            
            
          );
      // var r=this.apiService.getregno(this.tokenService.getid());
    
    // this.fdto.distanceID=distanceId;
    // console.log(r)
    //this.fdto=r;
    

    

  }

  getfare(distanceID:string,vehicleRegistrationNo:any) {
    console.log("dd"+distanceID)
   const params = new HttpParams()
.set('distanceID', distanceID)
.set('vehicleRegistrationNo', vehicleRegistrationNo);
console.log(params);
    this.http.get<any>(`${this.apiUrl}/rides/calculatefare`,{params},)
    .subscribe(
        (response: string) => {
          // Handle the response string
          console.log(response);
          this.Fare= "Fare : "+response;
          // Process the response further as needed
        },
        (error) => {
          // Handle errors
          console.error(error);
        }
      );
  }

  onSubmit(): void {
    // this.newride.
    console.log(this.newride.value);
    this.apiService.createRide(this.newride.value).subscribe(response => {
      console.log(response);
      // show acknowledgement message here
      this.submitted=true;
    }, error => {
      console.log(error);
      // show error message here
    });
  }

  

}
