import { Component, OnInit } from '@angular/core';
import { TokenService } from '../app.tokenservice';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit{
  isLoggedIn: boolean;
  constructor(private tokenService: TokenService){}

  ngOnInit(): void {
    console.log(this.tokenService.getToken());
    this.isLoggedIn=this.tokenService.getToken()!=null;
  }

}
