import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
  })
export class FareDTO{
    vehicleRegistrationNo:string;
    distanceID:string;

    // constructor({ vehicleRegistrationNo, distanceID }: { vehicleRegistrationNo: string; distanceID: string; }){
    //         this.distanceID=distanceID;
    //         this.vehicleRegistrationNo=vehicleRegistrationNo;
    //     }
}