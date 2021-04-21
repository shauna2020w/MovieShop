import { Component, Input, OnInit } from '@angular/core';
import { MovieCard } from '../../models/movie-card';

@Component({
  selector: 'app-movie-card',
  templateUrl: './movie-card.component.html',
  styleUrls: ['./movie-card.component.css']
})
export class MovieCardComponent implements OnInit {
  //movie card as child component of home component, 
  //getting data/model info input from parent
  //home component pass data by calling <app-movie-card> in its html 
  @Input() movie: MovieCard | undefined;  
  constructor() { }

  ngOnInit(): void {
  }

}
