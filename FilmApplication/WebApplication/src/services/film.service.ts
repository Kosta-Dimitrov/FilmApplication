import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Film } from "../models/film";
import { Observable } from 'rxjs';
import { Filter } from 'src/models/filter';

@Injectable({ providedIn: 'root' })
export class FilmService {
    configUrl: string = 'api/film';

    constructor(private http: HttpClient) { }

    getAllFilms(filter: Filter): Observable<Film[]> {
        if (filter.minLongevity != NaN) {
            return this.http.get<Film[]>(this.configUrl + "?name=" + filter.name + "&minLongevity=" + filter.minLongevity);
        }
        return this.http.get<Film[]>(this.configUrl + "?name=" + filter.name);
    }

    // getFilms(name: string, longevity: number): Observable<Film[]> {
    //     if (longevity != NaN) {
    //         return this.http.get<Film[]>(this.configUrl + "?name=" + name + "&minLongevity=" + longevity);
    //     }
    //     return this.http.get<Film[]>(this.configUrl + "?name=" + name);
    // }

    getFilmById(id: number): Observable<Film> {
        return this.http.get<Film>(`${this.configUrl}/${id}`);
    }

    updateFilm(film: Film): Observable<Film> {
        const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
        debugger
        return this.http.put<Film>(`${this.configUrl}/${film.id}`, film, httpOptions);
    }
}