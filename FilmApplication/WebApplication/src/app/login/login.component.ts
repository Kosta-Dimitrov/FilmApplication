import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/models/user';
import { AuthenticationService } from 'src/services/authentication.service';
import { TokenStorageService } from 'src/services/tokenStorage.service';

@Component({
    selector: 'app-login',
    templateUrl: 'login.component.html'
})

export class LoginComponent implements OnInit {
    user: User = {
        username: '',
        password: '',
    };
    constructor(private authService: AuthenticationService, private tokenStorage: TokenStorageService, private router: Router) { }

    hasError: boolean = false;
    ngOnInit() {
    }

    onSubmit(): void {
        //const { username, password } = this.form;
        this.authService.login(this.user).subscribe(
            data => {
                console.log(data.token);
                localStorage.setItem("id_token", data.token);
                localStorage.setItem("username", this.user.username!)
                this.authService.sendAuthStateChangeNotification(true);

                this.router.navigate(["/all"]);
            },
            err => {
                console.log(err);
                this.hasError = true;
            }
        );
    }
    reloadPage(): void {
        window.location.reload();
    }
}