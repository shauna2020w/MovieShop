import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/shared/models/user';
import { AuthenticationService } from '../../services/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  isAuthenticated: boolean | undefined;
  currentUser: User | undefined;
  currentUserName: string | undefined;
  constructor(private authService:AuthenticationService) { }

  ngOnInit(): void {

    this.authService.isAuthenticated.subscribe(
      auth =>{
        this.isAuthenticated = auth;
        console.log("check auth status:"+ this.isAuthenticated)
      }
    );

    this.authService.currentUser.subscribe(
      user =>{
        this.currentUser = user;
        this.currentUserName=user.given_name +" "+ user.family_name;
        console.log("current user:" + this.currentUserName)
      }
    );

    
  }

  logOut():void{
    this.authService.logout();
    console.log("here logged out:"+this.currentUser + this.isAuthenticated)
  }

}
