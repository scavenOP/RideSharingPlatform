import { HttpClient, HttpErrorResponse, HttpParams,HttpResponse } from "@angular/common/http";
import { EventEmitter, Injectable } from "@angular/core";
import { TokenService } from "../app.tokenservice";
import { Observable, throwError } from "rxjs";
import { catchError,map } from 'rxjs/operators';
import { FareDTO } from "./Models/model.faredto";



@Injectable({
    providedIn: 'root'
  })
  export class ApiService {
    private apiUrl = 'https://localhost:7083/api'; 
    public unAuthorisedError = new EventEmitter<void>();
    private token=this.tokenservice.getToken();
  
    constructor(private faredto:FareDTO,private http: HttpClient , private tokenservice: TokenService) {}

    getdistances(): Observable<any> {
        return this.http.get<any>(`${this.apiUrl}/distances`)
          .pipe(
            catchError(this.handleError)
          );
      }

      getregno(id:string){
        this.http.get(`${this.apiUrl}/GetRegNo/${id}`,{ responseType: 'text' })
        .subscribe(
            (response: string) => {
              // Handle the response string
              console.log("ff"+response);
              return response;
              // Process the response further as needed
            },
            
            (error) => {
              // Handle errors
              console.error(error);
              return "";
            },
            
            
          );
        
      }
      getfare(distanceID:string,vehicleRegistrationNo:any) {
        console.log("dd"+distanceID)
       const params = new HttpParams()
    .set('distanceID', distanceID)
    .set('vehicleRegistrationNo', vehicleRegistrationNo);
    console.log(params);
        this.http.get<any>(`${this.apiUrl}/rides/calculatefare`,{params},)
        .subscribe(
            (response: string) => {
              // Handle the response string
              console.log(response);
              return response;
              // Process the response further as needed
            },
            (error) => {
              // Handle errors
              console.error(error);
            }
          );
      }

      getRides(from:string,to:string,min:string,max:string):Observable<any> {
        const params = new HttpParams()
        .set('from',from)
        .set('to',to)
        .set('MinPrice',min)
        .set('MaxPrice',max);
        
        console.log(params);
        console.log(`${this.apiUrl}/rides/search`,{params});
        return this.http.get<any>(`${this.apiUrl}/rides/search`,{params})
        .pipe(
          catchError(this.handleError)
        );

      }

      createRide(applicationData: any): Observable<any> {
        return this.http.post<any>(`${this.apiUrl}/rides/schedule`, applicationData)
          .pipe(
            catchError(this.handleError)
          );
      }

      bookRide(applicationData: any): Observable<any> {
        return this.http.post<any>(`${this.apiUrl}/rides/book`, applicationData)
          .pipe(
            catchError(this.handleError)
          );
      }

      private handleError(error: HttpErrorResponse) {
        let errorMessage = 'An error occurred';
        if (error.error instanceof ErrorEvent) {
          // Client-side errors
          errorMessage = `Error: ${error.error.message}`;
        } else {
          // Server-side errors
    
          console.log(error);
          errorMessage = `Error Code: ${error.status}\nMessage: ${error}`;
        }
        if(error.status===401){
          this.unAuthorisedError.emit();
        }
        console.error(errorMessage);
        return throwError(error);
      }
  }
