
import { Component, OnInit } from '@angular/core';
import { MovieService } from 'src/app/core/services/movie.service';
import { MovieCard } from 'src/app/shared/models/movie-card';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {

  movies: MovieCard[] | undefined;
  constructor(private movieService: MovieService) { }

  ngOnInit() {
    this.movieService.getTop30GrossingMovies().subscribe(
      m => {
        this.movies = m;
      }
    )
  }
}


