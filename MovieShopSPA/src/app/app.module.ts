import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from'@angular/common/http';
import { FormsModule,ReactiveFormsModule } from '@angular/forms'; //all manully added

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { GenresComponent } from './genres/genres.component';
import { HeaderComponent } from './core/layout/header/header.component';
import { FooterComponent } from './core/layout/footer/footer.component';
import { MovieCardComponent } from './shared/components/movie-card/movie-card.component';
import { HomeComponent } from './home/home/home.component';
import { MovieDetailsComponent } from './movies/movie-details/movie-details.component';
import { MovieCardListComponent } from './movies/movie-card-list/movie-card-list.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';


@NgModule({   
  declarations: [
    AppComponent,
    GenresComponent,
    HeaderComponent,
    FooterComponent,
    MovieCardComponent,
    HomeComponent,
    MovieDetailsComponent,
    MovieCardListComponent,
    LoginComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
