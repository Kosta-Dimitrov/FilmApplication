import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { User } from 'src/models/user';
import { loginResponse } from 'src/models/loginResponse';

const Url = 'api/user';
const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({ providedIn: 'root' })
export class AuthenticationService {

    private authChangeSub = new Subject<boolean>()
    public authChanged = this.authChangeSub.asObservable();

    constructor(private http: HttpClient) { }

    public sendAuthStateChangeNotification = (isAuthenticated: boolean) => {
        this.authChangeSub.next(isAuthenticated);
    }

    login(user: User): Observable<loginResponse> {
        return this.http.post<loginResponse>(Url + '/login', user);
    }

    register(user: User): Observable<any> {
        return this.http.post(Url + '/register', user);
    }


}