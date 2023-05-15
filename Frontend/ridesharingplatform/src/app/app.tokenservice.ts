import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TokenService {
     _token: string;
     _name: string;
     _role:string;
    islogedin: boolean =false;

    
  
    // ...
    setid(value: string){
      localStorage.setItem("id",value);

    }
    getid(){
      return localStorage.getItem("id");
    }
  
    setname(value: string) {
      localStorage.setItem("name",value);
    }
  
    getname(){
      return localStorage.getItem("name");
    }
    public setToken(token: string) {
      localStorage.setItem("token",token);
  }

  getToken() {
    return localStorage.getItem("token");
  }

  setRole(role: string) {
    localStorage.setItem("role",role);
  }

  getRole() {
    return localStorage.getItem("role");
  }

  logout(): void{
    localStorage.removeItem("token");
    localStorage.removeItem("name");
    localStorage.removeItem("role");
  }
  
    // ...
  }
  