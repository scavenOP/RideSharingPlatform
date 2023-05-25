import { Component, ElementRef, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators, NgForm, ValidatorFn, AbstractControl } from '@angular/forms';
import { Router } from '@angular/router';

import { ReactiveFormsModule } from '@angular/forms';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { TokenService } from 'src/app/app.tokenservice';
import { VehicleApiService } from './api.service';

@Component({
  selector: 'app-addvehicle',
  templateUrl: './addvehicle.component.html',
  styleUrls: ['./addvehicle.component.scss']
})
export class AddvehicleComponent {

  newvehicle: FormGroup;
  vehicletype: any[] = [];
  isLoading = false;
  submitted: boolean;

  errorMessage: string = "";

  constructor(
    private formBuilder: FormBuilder,
    private dataService: VehicleApiService,
    private router: Router,
    private http: HttpClient,
    private tokenService: TokenService
  ) { }

  validateRegistrationNumber():ValidatorFn{
    return (control: AbstractControl): { [key: string]: any } | null => {
      const registrationNumber = control.value;
      if (registrationNumber && registrationNumber.length !== 10) {
        return { 'registrationNumberInvalid': true };
      }
      return null;
    };
    
  }

  validatepastdate():ValidatorFn{
    return(control: AbstractControl): { [key: string]:any}|null =>{
      const expdate = new Date(control.value);
      var d =new Date();
      //console.log(d); // regular expression for 10 digit phone number
      return expdate>=d ? null : { pastdate: true };
    }
  }

  validateregistrationdate():ValidatorFn{
    return(control: AbstractControl): { [key: string]:any}|null =>{
      const registrationdate = new Date(control.value);
      var cdate = new Date();
      const targetDate = new Date();
      targetDate.setFullYear(cdate.getFullYear() - 15);
      //console.log(d); // regular expression for 10 digit phone number
      return registrationdate.getTime() >= targetDate.getTime() ? null : { invalidregistrationdate: true };
    }
  }

  validateregistrationexpirydate():ValidatorFn{
    return(control: AbstractControl): { [key: string]:any}|null =>{
      const registrationdate = new Date(control.value);
      var cdate = new Date();
      const targetDate = new Date();
      targetDate.setFullYear(cdate.getFullYear() + 2);
      //console.log(d); // regular expression for 10 digit phone number
      return registrationdate.getTime() >= targetDate.getTime() ? null : { invalidregistrationexpirydate: true };
    }
  }

  validateinsauranceexpirydate():ValidatorFn{
    return(control: AbstractControl): { [key: string]:any}|null =>{
      const insaurancedate = new Date(control.value);
      var cdate = new Date();
      const targetDate = new Date();
      targetDate.setFullYear(cdate.getFullYear() + 1);
      //console.log(d); // regular expression for 10 digit phone number
      return insaurancedate.getTime() >= targetDate.getTime() ? null : { invalidinsauranceexpirydate: true };
    }
  }

  validatepucexpirydate():ValidatorFn{
    return(control: AbstractControl): { [key: string]:any}|null =>{
      const pucdate = new Date(control.value);
      var cdate = new Date();
      const targetDate = new Date();
      targetDate.setMonth(cdate.getMonth() + 6);
      //console.log(d); // regular expression for 10 digit phone number
      return pucdate.getTime() >= targetDate.getTime() ? null : { invalidpucexpirydate: true };
    }
  }

  validateregistrationnumber():ValidatorFn{
    return(control: AbstractControl): { [key: string]:any}|null =>{
      const registrationNumber = control.value;
      const validregistrationNumber = /^[A-Za-z]{2}\d{2}[A-Za-z]{2}\d{4}$/; // regular expression for 10 digit phone number
      return validregistrationNumber.test(registrationNumber) ? null : { invalidregistrationno: true };
    }
  }

  ngOnInit() {
    this.isLoading = true;
    this.newvehicle = new FormGroup({
      registrationNo: new FormControl('', [Validators.required,this.validateregistrationnumber()]),
      belongsToUserId: new FormControl(this.tokenService.getid(), Validators.required),
      vehicleTypeId: new FormControl('',Validators.required),
      inspectionStatus: new FormControl('pending', Validators.required),
      rtoName: new FormControl('', Validators.required),
      registrationDate: new FormControl("", [Validators.required]),
      registrationExpiresOn: new FormControl(new Date, [Validators.required,this.validateregistrationexpirydate()]),
      insuranceCompanyName: new FormControl('', Validators.required),
      insuranceNo: new FormControl('', Validators.required),
      insurancedOn: new FormControl(new Date, Validators.required),
      insuranceExpiresOn: new FormControl(new Date, [Validators.required,this.validateinsauranceexpirydate()]),
      pucCertificateNo: new FormControl(Validators.required),
      pucIssuedOn: new FormControl(new Date, Validators.required),
      pucValidUntil: new FormControl(new Date, [Validators.required,this.validatepucexpirydate()])
    });
    this.submitted = false;

    // Fetch the list of companies from the API
    this.dataService.getVehicleTypes().subscribe((response: any[]) => {


      this.vehicletype = response;
      this.isLoading = false;
      //console.log(this.tokenService.getToken());

    });

  }

  onSubmit(): void {
    this.isLoading = true;
    // if (this.newvehicle.invalid) {
    //   return;
    // }
     console.log(this.newvehicle.value)
  this.dataService.createVehicle(this.newvehicle.value).subscribe(response => {
      console.log(response);
      // show acknowledgement message here
      console.log("done");
      this.submitted=true;
    }, error => {
      console.log(error);
      // show error message here
    });
    this.isLoading = false;
 

}

}
