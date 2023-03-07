import { Injectable } from '@angular/core';
import jwt_decode from "jwt-decode";

const TOKEN_KEY = 'id_token';
const USER_KEY = 'auth-user';
@Injectable({ providedIn: 'root' })
export class TokenStorageService {
    constructor() { }

    signOut(): void {
        window.localStorage.clear();
    }
    getDecodedAccessToken(token: string): any {
        try {
            return jwt_decode(token);
        } catch (Error) {
            return null;
        }
    }
    public saveToken(token: string): void {
        window.localStorage.removeItem(TOKEN_KEY);
        window.localStorage.setItem(TOKEN_KEY, token);
    }
    public getToken(): string | null {
        return window.localStorage.getItem(TOKEN_KEY);
    }
    public saveUser(user: any): void {
        window.localStorage.removeItem(USER_KEY);
        window.localStorage.setItem(USER_KEY, JSON.stringify(user));
    }
    public getUser(): any {
        const user = window.localStorage.getItem(TOKEN_KEY);
        if (user) {
            return JSON.parse(user);
        }
        return {};
    }
    public isAdmin(): boolean {
        return this.getDecodedAccessToken(localStorage.getItem("id_token")!)["role"] == "Admin";
    }
}