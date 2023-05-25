import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute,Router } from '@angular/router';
import { TokenService } from '../app.tokenservice';
import { NavComponent } from '../nav/nav.component';
import { ApiService } from '../UserVerification/api.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit{
  
  loginForm: FormGroup;
  //formBuilder: any;
  isLoading:boolean;
  errorMessage:string;
  constructor(private route: ActivatedRoute,private router: Router,private formBuilder: FormBuilder,private loginService: ApiService,private tokenservice: TokenService,private navComponent: NavComponent){}
  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  onSubmit() {
    this.isLoading=true;
    const email = this.loginForm.controls['email'].value;
    const password = this.loginForm.controls['password'].value;
    this.loginService.login(email, password).subscribe(
      response => {
        // localStorage.setItem('token', response.token);
        // localStorage.setItem('username', response.name);
        // close the modal on successful login
        console.log(response.token);
        this.tokenservice.setname(response.name);
        this.tokenservice.setToken(response.token);
        this.tokenservice.setRole(response.role);
        this.tokenservice.setid(response.id);
        console.log(this.tokenservice.getid());
        console.log("name:" +this.tokenservice.getname());
        //console.log(this.tokenservice.getname());
        this.navComponent.currentUser=this.tokenservice.getname();
        //document.getElementById('closeModal').click();
        this.navComponent.currentuserrole=this.tokenservice.getRole();
        console.log("role"+this.navComponent.currentuserrole)
        this.isLoading=false;
        const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
        this.router.navigate([returnUrl]);
      },
      error => {
        this.errorMessage = error.message;
        console.log(error);
        this.isLoading=false;
      }
    );
  }


}
