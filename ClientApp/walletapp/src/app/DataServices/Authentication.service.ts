import { Observable } from "rxjs";
import { LoginModel } from "../Models/loginModel";
import { environment } from "src/environments/environment";
import { AuthModel } from "../Models/Authentication/AuthModel";
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
  })
  export class AuthenticationService {
    constructor(private http: HttpClient) { }

  
    login(loginModel: LoginModel): Observable<any> {
      let url: string = environment.apiBaseUrl + "api/Authentication/Login";
      return this.http.post<any>(url, loginModel);
    }
  
    saveAurhData(model: AuthModel): any {
      localStorage.setItem("token", JSON.stringify(model))
    }
  
    isAuthenticated(): boolean {
     
      let tokenString = localStorage.getItem("token");
      let auth = tokenString ? (JSON.parse(tokenString)) as AuthModel : null;

      if (auth == null)
        return false;
  
      if (auth.expiration <= new Date()) {
        this.logOut();
        return false;
      }
        return true;
    }
  
    getAuthData(): AuthModel | null {
    //   let auth: AuthModel = (JSON.parse(localStorage.getItem("token")) as AuthModel);

      let tokenString = localStorage.getItem("token");
      let auth = tokenString ? (JSON.parse(tokenString)) as AuthModel : null;
      return auth;
    }
  
    logOut() {
      localStorage.removeItem("token");
    }
  
    // authKeyExists(key: string): boolean {
    //   let permissions: string[] = JSON.parse(localStorage.getItem("token"))["permission"] as string[];
    //   console.log(permissions);
      
    //   if (!permissions)
    //     return false;
    //     console.log(permissions);
        
    //   return (JSON.parse(localStorage.getItem("token"))["permission"] as string[]).includes(key);
    // }


    isAdmin() {
        let tokenString = localStorage.getItem("token");
        let auth = tokenString ? (JSON.parse(tokenString)) as AuthModel : null;
        return auth;
    }


    
  
  
    // forgotPassword(model: ForgetPasswordModel): Observable<any> {
    //   let url: string = environment.apiBaseUrl + "api/Authentication/ForgotPassword";
    //   return this.http.post(url, model);
    // }
  
    // resetPassword(model: ResetPasswordModel): Observable<any> {
    //   let url: string = environment.apiBaseUrl + "api/Authentication/ResetPassword";
    //   return this.http.post(url, model);
    // }
  
  
  }
  