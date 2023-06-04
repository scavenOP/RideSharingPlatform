import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { TokenService } from 'src/app/app.tokenservice';
import { ApiService } from '../RideApi.service';

@Component({
  selector: 'app-book-ride',
  templateUrl: './book-ride.component.html',
  styleUrls: ['./book-ride.component.scss']
})
export class BookRideComponent implements OnInit{

  rideId:string;
  bRide:FormGroup;
  isLoading:boolean;
  isBooked:boolean;

  ngOnInit(): void {
    this.isLoading=true;
    this.route.queryParams.subscribe(params =>{
      this.rideId=params['rideId'];

      
    });

    this.bRide = new FormGroup({
      bookedOn: new FormControl(new Date()),
      riderUserId: new FormControl(this.tokenService.getid()),
      noOfSeats: new FormControl(0,Validators.required),
      paymentMode: new FormControl('',Validators.required),
      rideSchedulesID:new FormControl(this.rideId)

    })
    this.isLoading=false;
    
  }

  constructor(private route:ActivatedRoute, private tokenService:TokenService, private apiService: ApiService){}

  onSubmit(){
    this.isLoading=true;

    console.log(this.bRide.value);
    this.apiService.bookRide(this.bRide.value).subscribe(response => {
      console.log(response);
      // show acknowledgement message here
      this.isBooked=true;
      this.isLoading=false;
    }, error => {
      console.log(error);
      // show error message here
    });

  }

}
