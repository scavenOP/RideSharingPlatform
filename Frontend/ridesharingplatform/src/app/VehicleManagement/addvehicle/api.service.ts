import { EventEmitter, Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError,map } from 'rxjs/operators';
import { TokenService } from 'src/app/app.tokenservice';



@Injectable({
  providedIn: 'root'
})
export class VehicleApiService {
  private apiUrl = 'https://localhost:7083/api'; 
  public unAuthorisedError = new EventEmitter<void>();
  private token=this.tokenservice.getToken();

  constructor(private http: HttpClient , private tokenservice: TokenService) {}

  getVehicleTypes(): Observable<any> {
    this.token=this.tokenservice.getToken();
    console.log("ht " +this.token);
    const headers=new HttpHeaders({Authorization: 'Bearer '+this.token});
    return this.http.get<any>(`${this.apiUrl}/vehicles/vehicletypes`,{headers})
      .pipe(
        catchError(this.handleError)
      );
  }

  createVehicle(applicationData: any): Observable<any> {
    this.token=this.tokenservice.getToken();
    console.log("ht " +this.token);
    const headers=new HttpHeaders({Authorization: 'Bearer '+this.token});
    return this.http.post<any>(`${this.apiUrl}/vehicles/add/vehicle`, applicationData,{headers})
      .pipe(
        catchError(this.handleError)
      );
  }

  getVehiclebuUser(id:string): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/vehicle/${id}`)
      .pipe(
        catchError((error) =>{
        return throwError(()=> new Error(error));})
      );
  }

  getPendingVehicles(): Observable<any> {
    this.token=this.tokenservice.getToken();
    console.log("ht " +this.token);
    const headers=new HttpHeaders({Authorization: 'Bearer '+this.token});
    return this.http.get<any>(`${this.apiUrl}/vehicle/pendingvehicles`,{headers})
    .pipe(
      catchError(this.handleError)
    );
  }

  updatevehicle(updatedata:any):Observable<any> {
    this.token=this.tokenservice.getToken();
    console.log("ht " +this.token);
    const headers=new HttpHeaders({Authorization: 'Bearer '+this.token});
    return this.http.put<any>(`${this.apiUrl}/vehicles/approveorreject`,updatedata,{headers})
    .pipe(
      catchError(this.handleError)
    );
    
  }

  deleteVehicle(regno:string):Observable<any>{

    this.token=this.tokenservice.getToken();
    console.log("ht " +this.token);
    const headers=new HttpHeaders({Authorization: 'Bearer '+this.token});

    return this.http.delete(`${this.apiUrl}/vehicles/delete/${regno}`,{headers})
    .pipe(
      catchError((error) =>{
        return throwError(()=> new Error(error));
      })
    )
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
