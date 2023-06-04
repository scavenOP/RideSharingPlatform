import { EventEmitter, Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError,map } from 'rxjs/operators';
import { TokenService } from 'src/app/app.tokenservice';



@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiUrl = 'https://localhost:7083/api'; 
  public unAuthorisedError = new EventEmitter<void>();
  private token=this.tokenservice.getToken();

  constructor(private http: HttpClient , private tokenservice: TokenService) {}

  getCompanies(): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/companies`)
      .pipe(
        catchError(this.handleError)
      );
  }

  createApplication(applicationData: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/applications/new`, applicationData)
      .pipe(
        catchError(this.handleError)
      );
  }

  getPendingApplications(): Observable<any> {
    // this.token= "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJyb2xlIjoiU2VjdXJpdHlIZWFkIiwiUm9sZUlkIjoiMyIsInByZWZlcnJlZF91c2VybmFtZSI6IkFtaXQgU2F1IiwiaWQiOiIxIiwiZW1haWwiOiJhbWl0QGN0cy5jb20iLCJuYmYiOjE2ODM3MTM0MjAsImV4cCI6MTY4NjMwNTQyMCwiaWF0IjoxNjgzNzEzNDIwfQ.br1CXxLqlHy-dHg3QyJUWgpCd8UKK8GFw8PQUGctLDE";
    // console.log(this.token);
    this.token=this.tokenservice.getToken();
    console.log("ht " +this.token);
    const headers=new HttpHeaders({Authorization: 'Bearer '+this.token});

    return this.http.get<any>(`${this.apiUrl}/applications`,{headers})
      .pipe(
        catchError(this.handleError)
        
      );
  }

  updateApplicationStatus(applicationData: any): Observable<any> {
    
    //const body = { id: applicationId, status: status };
    console.log(applicationData);
    return this.http.put<any>(`${this.apiUrl}/applications/approvereject`, applicationData)
      .pipe(
        catchError(error => {
          console.log(error.error);
          return throwError("er");
        })
      );
  }

  getApplicationById(applicationId: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/applications/${applicationId}`)
      .pipe(
        catchError((error) =>{
        return throwError(()=> new Error(error));})
      );
  }

  login(email: string, password: string): Observable<{ id:string, name: string, token: string,role:string  }> {
    const url = `${this.apiUrl}/Auth/login`;
    const body = { email, password };
    return this.http.post<{ id:string,name: string, token: string,role:string }>(url, body)
      .pipe(
        map(response => {
          this.tokenservice.setToken(response.token);
          this.tokenservice.setRole(response.role);
          this.tokenservice.setname(response.name);
          this.tokenservice.setid(response.id);
          return response;
        }),
        catchError(error => {
          console.log(error.error);
          let message = 'An error occurred while logging in';
          if (error.status === 500 && error.error.message) {
            message = error.error;
          }
          return throwError(() => new Error(error.error));
        })
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
