import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MovieCard } from 'src/app/shared/models/movie-card';
import { MovieDetails } from 'src/app/shared/models/movie-detail';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  constructor(private apiService:ApiService) { }

  getTop30GrossingMovies(): Observable<MovieCard[]>{
    return this.apiService.getAll(`movie/toprevenue`);
  }

  getMoviesByGenreId(genreId: number): Observable<MovieCard[]>{
    return this.apiService.getAll(`movie/genre/${genreId}`);
  }

  getMovieDetails(movieId: number): Observable<MovieDetails>{
    return this.apiService.getById(`movie/${movieId}`);
  }

}
