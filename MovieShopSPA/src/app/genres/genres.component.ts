import { Component, OnInit } from '@angular/core';
import { GenreService } from '../core/services/genre.service';
import { GenreModel } from '../shared/models/genre';

@Component({
  selector: 'app-genres',
  templateUrl: './genres.component.html',
  styleUrls: ['./genres.component.css']
})
export class GenresComponent implements OnInit {
  
  genres:GenreModel[] | undefined;

  constructor(private genreService: GenreService) { }

  ngOnInit() {  //liftcycle hook

    this.genreService.getAllGenres().subscribe(
      g=>{
        this.genres = g;
        console.table(this.genres);
      }
    )
  }

}
