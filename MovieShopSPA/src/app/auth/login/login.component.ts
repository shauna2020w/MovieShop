import { Component, OnInit } from '@angular/core';
import { Login } from 'src/app/shared/models/login';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService} from 'src/app/core/services/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

//this component is to build forms

//two ways to build forms: 
//1.template driven: small from with simple logic  <----Login
//2.reactive fomrs: complex                        <---- will take Register, create movie as examples     
export class LoginComponent implements OnInit {

//one-way-binding: push single data/view compo from parent to child
//two-way-binding: bind view and component, data passed, get update in view, update data  
//<---  one way e.g login() - Submit form, we submit data to component, (not server)
//two way: e.g twowayInfo() -     

  userLogin:Login ={email:'',password:''};
  invalidLogin: boolean = false;

  constructor(private authService: AuthenticationService, private router: Router) { }

  ngOnInit(): void {
  }

  login(f:NgForm) {
    this.authService.login(this.userLogin).subscribe(
      (response) => {
        if (response) {
          this.router.navigate(['/']);
        }
        else{
          this.invalidLogin = true;
        }
      },
      (err: any) => { this.invalidLogin = true, console.log(err) }
    );
  }

  get twowayInfo() { return JSON.stringify(this.userLogin); }
}

