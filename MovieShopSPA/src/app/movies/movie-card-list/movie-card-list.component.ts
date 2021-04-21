import { Component, OnInit } from '@angular/core';
import { MovieService } from 'src/app/core/services/movie.service';
import { MovieCard } from 'src/app/shared/models/movie-card';
import { ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-movie-card-list',
  templateUrl: './movie-card-list.component.html',
  styleUrls: ['./movie-card-list.component.css']
})
export class MovieCardListComponent implements OnInit {

  //movie in genre, is child component of genre component
  //which needs genre data as input, getting from parent 
  genreId: number | undefined;                          //
  movies: MovieCard[] | undefined;           //

  constructor(private movieService: MovieService, private route: ActivatedRoute) { }
  ngOnInit() {  
    this.route.paramMap.subscribe((params : ParamMap)=> {  
        let id = params.get('id');

        if (id!= 'undefined' && id != null){
          this.genreId = +id;
          this.movieService.getMoviesByGenreId(this.genreId).subscribe(m => {
          this.movies = m;
          // console.table(this.movies);
        })}else{
          console.log("genreId is not defined");
          this.movies = [];
        }
        
    });
  }
}
