import { Component, OnInit } from '@angular/core';
import { Film } from 'src/models/film';
import { FilmService } from 'src/services/film.service';

@Component({
    selector: 'app-content',
    templateUrl: 'content.component.html'
})

export class ContentComponent implements OnInit {

    constructor(private filmSer: FilmService) {

    }
    films: Film[] = [];
    ngOnInit() {
        //this.getFilms();
    }
    // getFilms(): void {
    //     this.filmSer.getAllFilms()
    //         .subscribe(films => this.films = films);
    // }
}