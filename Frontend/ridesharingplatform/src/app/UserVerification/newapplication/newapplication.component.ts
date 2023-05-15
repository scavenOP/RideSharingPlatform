
import { Component, ElementRef, OnInit } from '@angular/core';
import { FormBuilder, FormGroup,FormControl, Validators, NgForm, ValidatorFn, AbstractControl } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from '../api.service';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { TokenService } from 'src/app/app.tokenservice';

@Component({
  selector: 'app-newapplication',
  templateUrl: './newapplication.component.html',
  styleUrls: ['./newapplication.component.scss']
})
export class NewapplicationComponent implements OnInit {

  newapplication: FormGroup ;
  companyList: any[]=[];
  isLoading=false;
  submitted:boolean;
  
  errorMessage: string="";
  
  

  constructor(
    private formBuilder: FormBuilder,
    private dataService: ApiService,
    private router: Router,
    private http: HttpClient,
    private tokenService : TokenService
  ) { }

  validatePhoneNumber():ValidatorFn{
    return (control: AbstractControl): { [key: string]: any } | null => {
      const phoneNumber = control.value;
      if (phoneNumber && phoneNumber.length !== 10) {
        return { 'phoneNumberInvalid': true };
      }
      return null;
    };
    
  }

  validateAadharNumber():ValidatorFn{
    return (control: AbstractControl): { [key: string]: any } | null => {
      const phoneNumber = control.value;
      if (phoneNumber && phoneNumber.length !== 12) {
        return { 'aadharNumberInvalid': true };
      }
      return null;
    };
    
  }

  validatelicensenumber():ValidatorFn{
    return(control: AbstractControl): { [key: string]:any}|null =>{
      const phoneNumber = control.value;
      const validPhoneNumber = /^[A-Za-z]{3}\d{4}[A-Za-z]{3}$/; // regular expression for 10 digit phone number
      return validPhoneNumber.test(phoneNumber) ? null : { invalidlicenseno: true };
    }
  }
  validateexpdate():ValidatorFn{
    return(control: AbstractControl): { [key: string]:any}|null =>{
      const expdate = new Date(control.value);
      var d =new Date();
      console.log(d); // regular expression for 10 digit phone number
      return expdate>=d ? null : { invalidexpdate: true };
    }
  }

  ngOnInit() {
    this.isLoading=true;
    this.newapplication = new FormGroup({
      username: new FormControl('',Validators.required),
      password: new FormControl('',Validators.required),
      officialEmail: new FormControl('',Validators.required),
      phoneNumber: new FormControl('',[Validators.required, this.validatePhoneNumber()]),
      designation: new FormControl('',Validators.required),
      roleId: new FormControl('',Validators.required),
      employeeeId: new FormControl('',Validators.required),
      aadharNumber: new FormControl('',[Validators.required, this.validateAadharNumber()]),
      applicationStatus: new FormControl('New'),
      companyId: new FormControl('',Validators.required),
      licenseNo: new FormControl(null,[this.validatelicensenumber()]),
      expirationDate: new FormControl(new Date,this.validateexpdate()),
      rta: new FormControl(),
      alowedVehicles: new FormControl(),
    });
    this.submitted=false;

    // Fetch the list of companies from the API
    this.dataService.getCompanies().subscribe((response: any[]) => {
    
      
      this.companyList = response;
      this.isLoading=false;
      console.log(this.tokenService.getToken());
      
    });
    
  }
  

  // Handler for form submission
  onSubmit(): void {
    // if (this.newapplication.invalid) {
    //   return;
    // }
    console.log(this.newapplication.value)
  this.dataService.createApplication(this.newapplication.value).subscribe(response => {
      console.log(response);
      // show acknowledgement message here
      this.submitted=true;
    }, error => {
      console.log(error);
      // show error message here
    });
  

}
}