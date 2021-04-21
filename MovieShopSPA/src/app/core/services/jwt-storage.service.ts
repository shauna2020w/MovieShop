import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class JwtStorageService {

  constructor() { }

  getToken(){
    return localStorage.getItem('token');
  }

  saveToken(token: string){
    localStorage.setItem('token',token);
  
  }

  removeToken(){
    localStorage.removeItem('token');
  }
}
