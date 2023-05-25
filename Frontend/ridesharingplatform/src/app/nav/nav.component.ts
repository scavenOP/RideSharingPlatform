import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../UserVerification/api.service';
import { EventEmitter, Injectable } from '@angular/core';
import { TokenService } from '../app.tokenservice';
import { Router } from '@angular/router';
@Injectable({
  providedIn: 'root'
})
@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit{
  loginForm: FormGroup;
  errorMessage: string;
  currentUser: string;
  isLoading=false;
  currentuserrole:string=null;
  localservice:TokenService;

  constructor(private router: Router,private formBuilder: FormBuilder, private loginService: ApiService,private tokenservice: TokenService) { }

  ngOnInit() {
    console.log("user"+this.currentuserrole);
    
    this.loginService.unAuthorisedError.subscribe(()=>{
      this.currentUser=this.tokenservice.getname();
      this.localservice=this.tokenservice;
      this.currentuserrole=this.tokenservice.getRole();
      console.log("user"+this.currentuserrole);
      
      
    })
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
    
  }

  isrider(): boolean{
    var r = this.tokenservice.getRole() =="Rider";
    //console.log(r);
    return r;

  }
  issecurity(): boolean{
    var r = this.tokenservice.getRole() =="SecurityHead";
    //console.log(r);
    return r;

  }
  ismotorist(): boolean{
    var r = this.tokenservice.getRole() =="Motorist";
    //console.log(r);
    return r;

  }

  

  isLoggedIn(): boolean {
    var r =this.tokenservice.getToken() != null;
    if(r==true){
    this.currentUser=this.tokenservice.getname();
      
      //console.log("user"+this.currentUser);
      }
      return r;
  }
  logout(): void {
    this.tokenservice.logout();
    this.router.navigate([''])
  }
  // onSubmit() {
  //   this.isLoading=true;
  //   const email = this.loginForm.controls['email'].value;
  //   const password = this.loginForm.controls['password'].value;
  //   this.loginService.login(email, password).subscribe(
  //     response => {
  //       // localStorage.setItem('token', response.token);
  //       // localStorage.setItem('username', response.name);
  //       // close the modal on successful login
  //       console.log(response.token);
  //       this.tokenservice.setname(response.name);
  //       this.tokenservice.setToken(response.token);
  //       this.tokenservice.setRole(response.role;
  //       this.currentUser=this.tokenservice.getname();
  //       document.getElementById('closeModal').click();
  //       this.isLoading=false;
  //     },
  //     error => {
  //       this.errorMessage = error.message;
  //       console.log(error);
  //       this.isLoading=false;
  //     }
  //   );
  }



