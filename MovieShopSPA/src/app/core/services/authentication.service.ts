import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Login } from 'src/app/shared/models/login';
import { User } from 'src/app/shared/models/user';
import { ApiService } from './api.service';
import { JwtStorageService } from './jwt-storage.service';
import { JwtHelperService } from "@auth0/angular-jwt";
import { Register } from 'src/app/shared/models/register';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  

  private user!: User;
  private currentUserSubject = new BehaviorSubject<User>({}as User);
  public currentUser = this.currentUserSubject.asObservable();
  private isAuthenticatedSbuject = new BehaviorSubject<boolean>(false);
  public isAuthenticated = this.isAuthenticatedSbuject.asObservable();

  constructor(private apiService:ApiService,private jwtStorageSercie: JwtStorageService) { }

  register(userRegister: Register):Observable<boolean> {
    
    return this.apiService.create('account/register',userRegister)
    .pipe(map(resp =>{
        if(resp){
          return true;
        }
        return false;
      }));
  }

  login(userLogin: Login): Observable<boolean>{
     //take un/pw from login component and post it to API
    // once API returns token. we need to store the token in localstorage of the browser. 
    // otherwise return false to component to that component can show the message in the UI
    return this.apiService.create('account/login',userLogin)
    .pipe(map(resp =>{
        if(resp){
          //save the response token to local storage
          console.log(resp);
          this.jwtStorageSercie.saveToken(resp.token);
          this.populateUserInfo();
          return true;
        }
        return false;
      }));
  }

  logout(){
    //remove token
    this.jwtStorageSercie.removeToken();
    //settting default values to observables
    this.currentUserSubject.next({}as User); 
    this.isAuthenticatedSbuject.next(false);
  }

  decodeToken(){
    //token is encoded, this method will read token and decode it, put it in user obj
    //also check token not expired
    const token = this.jwtStorageSercie.getToken();
    if (token!=null) {
      const  tokenExpired = new JwtHelperService().isTokenExpired(token);
      if (tokenExpired || !token)
      {
        return null;
      }else{
        const decodedToken =  new JwtHelperService().decodeToken(token);
        this.user = decodedToken;
        return this.user;
      }
    }
    return null;
  }

  populateUserInfo(){
    if(this.jwtStorageSercie.getToken())
    {
      // const token = this.jwtStorageSercie.getToken();
      const decodedToken = this.decodeToken();
      if (decodedToken !=null)
       {
        this.currentUserSubject.next(decodedToken);
        this.isAuthenticatedSbuject.next(true);
      }
    }
  }
}
