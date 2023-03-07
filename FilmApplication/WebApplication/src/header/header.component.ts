import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/services/authentication.service';
import { TokenStorageService } from 'src/services/tokenStorage.service';
import jwt_decode from "jwt-decode";

@Component({
    selector: 'app-header',
    templateUrl: 'header.component.html',
    styleUrls: [`header.component.css`]
})

export class HeaderComponent implements OnInit {
    constructor(private authService: AuthenticationService, private tokenService: TokenStorageService) { }

    isUserLoggedIn: boolean = localStorage.getItem("id_token") != null;
    username: string | undefined;

    logout() {
        this.tokenService.signOut();
        window.location.reload();
    }

    ngOnInit() {
        this.isUserLoggedIn = localStorage.getItem("id_token") != null;
        this.authService.authChanged
            .subscribe(res => {
                this.isUserLoggedIn = res;
            });
        if (this.isUserLoggedIn) {
            //this.username = localStorage.getItem("username") || "";
            //this.username = atob(localStorage.getItem("id_token")!.split('.')[1])
            debugger
            this.username = this.tokenService.getDecodedAccessToken(localStorage.getItem("id_token")!)["unique_name"];
        }

    }
}