import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { TokenService } from 'src/app/app.tokenservice';
import { BookRideComponent } from '../book-ride/book-ride.component';
import { ApiService } from '../RideApi.service';

@Component({
  selector: 'app-search-rides',
  templateUrl: './search-rides.component.html',
  styleUrls: ['./search-rides.component.scss']
})
export class SearchRidesComponent implements OnInit{

  from:string[]=[];
  to:string[]=[];
  rides:any;
  isLoading:boolean;
  newsearch: FormGroup ;
  isSearching:boolean;
  searched:boolean=false;

  constructor(private router: Router,private http: HttpClient , private tokenservice: TokenService, private formBuilder: FormBuilder,private apiService:ApiService){}

  ngOnInit(): void {
    this.isLoading=true;

    this.apiService.getdistances().subscribe((response: any[]) => {
    console.log(response);
      
      for (let index = 0; index < response.length; index++) {
        console.log(response[index].from);
        this.from.push(response[index].from);
        this.to.push(response[index].to);
        
      }
      
      this.newsearch= new FormGroup({
        from:new FormControl(''),
        to:new FormControl(''),
        minPrice:new FormControl(0),
        maxPrice:new FormControl(1000)
      })
      ;
      this.isLoading=false;
      //console.log(this.tokenService.getToken());
      
    });

  }

  onSubmit(): void{
    this.isSearching=true;
    this.apiService.getRides(this.newsearch.get('from').value,this.newsearch.get('to').value,this.newsearch.get('minPrice').value,this.newsearch.get('maxPrice').value)
    .subscribe((response: any[]) => {
      this.rides=response;
      console.log(this.rides);

      this.isSearching=false;
      
    })

    

      
  }
  bookRide(id:String){
    console.log(id);
      this.router.navigate(['/book-ride'],{queryParams:{rideId:id}});
  } 


}
