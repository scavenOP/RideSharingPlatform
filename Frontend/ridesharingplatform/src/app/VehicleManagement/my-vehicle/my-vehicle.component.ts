import { Component, OnInit } from '@angular/core';
import { Vehicle } from '../models/model.vehicle';
import { ActivatedRoute, Router } from '@angular/router';
import { VehicleApiService } from '../addvehicle/api.service';
import { TokenService } from 'src/app/app.tokenservice';
//import { Vehicle } from './vehicle';

@Component({
  selector: 'app-my-vehicle',
  templateUrl: './my-vehicle.component.html',
  styleUrls: ['./my-vehicle.component.scss']
})
export class MyVehicleComponent implements OnInit{

  uservehicle:Vehicle =null;
  userid:string;
  isLoading:boolean=false;
  deleted:boolean=false;

  constructor(private router: Router,private route: ActivatedRoute, private apiService: VehicleApiService,private tokenService: TokenService){}

  ngOnInit(): void {
    this.isLoading=true;
    this.userid=this.tokenService.getid();

    this.getvehicleByUserID(this.userid);
    this.isLoading=false;
    console.log("bl "+this.uservehicle);

  }

  getvehicleByUserID(userId: string): void{
    this.apiService.getVehiclebuUser(userId).subscribe(
      (vehicle:Vehicle) => {
        this.uservehicle =vehicle;
        console.log(this.uservehicle);
    //     
      },
      (error:any) => {
        console.log(error);
      });
    
  }
  deleteVehicle(): void{
    this.isLoading=true;
    this.apiService.deleteVehicle(this.uservehicle.registrationNo).subscribe(response => {
      console.log(response);
      this.isLoading=false;
      this.deleted=true;
    });
      this.router.navigate(['my-vehicle']);
    
  }

}


