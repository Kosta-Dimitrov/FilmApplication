import { Component, OnInit } from '@angular/core';
import { Film } from 'src/models/film';
import { FilmService } from 'src/services/film.service';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

@Component({
    selector: 'app-filmDetail',
    templateUrl: 'filmDetail.component.html'
})

export class FilmDetailComponent implements OnInit {
    constructor(private filmService: FilmService, private route: ActivatedRoute, private location: Location) { }

    film: Film | undefined;
    ngOnInit() {

        this.filmService.getFilmById(this.getFilmId()).subscribe(film => this.film = film);
    }
    getFilmId(): number {
        const id = Number(this.route.snapshot.paramMap.get('id'));
        return id;
    }
}