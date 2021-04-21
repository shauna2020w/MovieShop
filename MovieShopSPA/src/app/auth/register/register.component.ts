import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { Login } from 'src/app/shared/models/login';
import { Register } from 'src/app/shared/models/register';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  userRegister:Register  = {email:'',password:'',firstName:'',lastName:'',dateOfBirth:new Date('0000-00-00')};
  userLogin:Login = {email:'',password:''}
  invalidRegister:boolean = false;
  invalidLogin: boolean = false;

  constructor(private authService: AuthenticationService, private router: Router) { }

  ngOnInit(): void {
  }

  register(f:NgForm){
    this.authService.register(this.userRegister).subscribe(
      (response) => {
        if (response) {
          this.userLogin.email = this.userRegister.email;
          this.userLogin.password = this.userRegister.password;  
          this.authService.login(this.userLogin).subscribe(
            (response) => {
              if (response) {
                this.router.navigate(['/']);
              }
            }
          )
        }
        else{
          this.invalidRegister = true;
        }
      },
      (err: any) => { this.invalidRegister = true, console.log(err) }
    );
  }
}
