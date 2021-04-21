import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GenreModel } from 'src/app/shared/models/genre';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class GenreService {

  constructor(private apiService:ApiService) { } //in order to go to / gerne, need link api and genre service. 

  getAllGenres(): Observable<GenreModel[]> { // navbar calls this method, method(): model[], model is created in shared/model
    // https://localhost:44367/api/Genre
    //make a call to API to get json data and wrap it tin genre array and return
    //call base apiservice which is gonna call API using httpclient class
    return this.apiService.getAll('genre');
  }
}
