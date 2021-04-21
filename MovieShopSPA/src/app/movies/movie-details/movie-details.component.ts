import { Component, OnInit } from '@angular/core';
import { MovieService } from 'src/app/core/services/movie.service';
import { MovieDetails } from 'src/app/shared/models/movie-detail';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { MovieCard } from 'src/app/shared/models/movie-card';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})

export class MovieDetailsComponent implements OnInit {
  details:MovieDetails | undefined;
  movieId: number | undefined;
  movie: MovieCard | undefined;

  constructor(private movieService:MovieService,private route: ActivatedRoute) { }

  ngOnInit(){
      this.route.paramMap.subscribe(params => {
          // console.log(params);
          // console.log(params.get('id'));

          let id = params.get('id');
          if (id != 'undefined' && id != null)
          {
            this.movieId = +id;
            this.movieService.getMovieDetails(this.movieId).subscribe(d=>{
              this.details = d;
              this.movie = {
                id: d.id,
                title: d.title,
                posterUrl: d.posterUrl
            }});
            console.log(this.details);
            console.log(this.movie);
          }else{
            console.table("movie id is not defined")
          }
      })  
  };
}