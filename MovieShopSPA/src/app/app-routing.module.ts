import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MovieDetailsComponent } from './movies/movie-details/movie-details.component';
import { MovieCardListComponent } from './movies/movie-card-list/movie-card-list.component';
import { HomeComponent } from './home/home/home.component';
import {LoginComponent } from './auth/login//login.component';
import {RegisterComponent } from './auth/register/register.component';

const routes: Routes =
  [

    { path: "", component: HomeComponent },
    { path: "movie/genre/:id", component: MovieCardListComponent },
    { path: "movie/:id", component: MovieDetailsComponent },
    { path: "login", component: LoginComponent},
    { path: "register", component: RegisterComponent}

  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
