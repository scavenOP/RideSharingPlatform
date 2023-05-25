import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { VehicleApiService } from '../addvehicle/api.service';
import { TokenService } from 'src/app/app.tokenservice';
import { Vehicle } from '../models/model.vehicle';
import { UVehicle } from '../models/model.uvehicle';

@Component({
  selector: 'app-approve-reject-vehicle',
  templateUrl: './approve-reject-vehicle.component.html',
  styleUrls: ['./approve-reject-vehicle.component.scss']
})
export class ApproveRejectVehicleComponent implements OnInit {
  vehicles: Vehicle[] = []; // Contains the list of pending vehicles
  currentVehicleIndex = 0;
  isLoading:boolean;
  uvehicle:UVehicle;// = new UVehicle("","","",new Date());
  V:Vehicle;
  updated:boolean=false;

  get vehicle(): Vehicle | undefined {
    return this.vehicles[this.currentVehicleIndex];
  }



  constructor(private router: Router,private route: ActivatedRoute, private apiService: VehicleApiService,private tokenService: TokenService){}

  ngOnInit(): void {
    this.isLoading = true;
    this.pendingvehicles();
    this.isLoading = false;
    
    

  }

  pendingvehicles(): void {
    this.apiService.getPendingVehicles().subscribe((response: any[]) => {


      this.vehicles = response;
      
      //console.log(this.tokenService.getToken());

    });
  }

  navigateNext() {
    if (!this.isLastVehicle()) {
      this.currentVehicleIndex++;
    }
  }

  navigatePrevious() {
    if (!this.isFirstVehicle()) {
      this.currentVehicleIndex--;
    }
  }

  isFirstVehicle(): boolean {
    return this.currentVehicleIndex === 0;
  }

  isLastVehicle(): boolean {
    return this.currentVehicleIndex === this.vehicles.length - 1;
  }

  approveVehicle() {
    console.log(this.vehicle.registrationNo);
    
    console.log(new Date());
    this.uvehicle=new UVehicle(this.vehicle.registrationNo,"approved",Number(this.tokenService.getid()),new Date())
    this.apiService.updatevehicle(this.uvehicle).subscribe(response=>{
      console.log(response);
      this.updated=true;



    })
    document.getElementById('closemodal').click();
    console.log(this.uvehicle);
  }

  rejectVehicle() {
    // Implement the logic to reject the current vehicle
    // Example:
    console.log('Vehicle rejected:', this.vehicle);
  }


}
