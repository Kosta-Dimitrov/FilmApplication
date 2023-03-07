import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/models/user';
import { AuthenticationService } from 'src/services/authentication.service';

@Component({
    selector: 'app-register',
    templateUrl: 'register.component.html'
})

export class RegisterComponent implements OnInit {
    hasError: boolean = false;
    user: User = {
        username: undefined,
        password: undefined
    };
    constructor(private authService: AuthenticationService, private router: Router) { }

    ngOnInit() { }

    onSubmit(): void {
        //const { username, password } = this.form;
        this.authService.register(this.user).subscribe(
            data => {
                this.router.navigate(["/all"]);
            },
            err => {
                this.hasError = true;
            }
        );
    }
}