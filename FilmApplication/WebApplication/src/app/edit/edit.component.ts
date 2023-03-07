import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Film } from 'src/models/film';
import { FilmService } from 'src/services/film.service';

@Component({
    selector: 'app-edit',
    templateUrl: 'edit.component.html'
})

export class EditComponent implements OnInit {
    constructor(private filmService: FilmService, private route: ActivatedRoute, private router: Router) { }

    film: Film = {
        imageUrl: '',
        description: '',
        id: 0,
        duration: 0,
        name: ''
    };
    hasError: boolean = false;

    ngOnInit() {

        this.filmService.getFilmById(this.getFilmId()).subscribe(film => this.film = film);
    }
    getFilmId(): number {
        const id = Number(this.route.snapshot.paramMap.get('id'));
        return id;
    }
    submit() {
        debugger
        this.filmService.updateFilm(this.film).subscribe(
            data => {
                this.router.navigate(["/all"]);
            },
            err => {
                this.hasError = true;
                console.log(err);
            }
        );
    }
}