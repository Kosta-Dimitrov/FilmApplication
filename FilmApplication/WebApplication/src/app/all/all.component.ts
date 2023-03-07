import { Component, OnInit } from '@angular/core';
import { Film } from 'src/models/film';
import { Filter } from 'src/models/filter';
import { FilmService } from 'src/services/film.service';
import { TokenStorageService } from 'src/services/tokenStorage.service';

@Component({
    selector: 'app-all',
    templateUrl: 'all.component.html',
    styleUrls: [`all.component.css`]
})

export class AllComponent implements OnInit {
    constructor(public filmService: FilmService, private tokenService: TokenStorageService) {
    }
    filter: Filter = {
        name: "",
        minLongevity: 0
    };
    films: Film[] | undefined;
    isAdmin: boolean = false;
    ngOnInit() {
        this.filmService.getAllFilms(this.filter).subscribe(films => this.films = films);
        this.isAdmin = this.tokenService.isAdmin();
    }

    public search() {
        this.filmService.getAllFilms(this.filter).subscribe(films => this.films = films)
    }
}