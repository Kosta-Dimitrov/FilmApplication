import { Component, OnInit } from '@angular/core';
import { TokenStorageService } from 'src/services/tokenStorage.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'FinalProject';
  private roles: string[] = [];
  isLoggedIn = false;
  username?: string;
  constructor(private tokenStorageService: TokenStorageService) {
  }
  ngOnInit(): void {

    this.isLoggedIn = !!this.tokenStorageService.getToken();
    if (this.isLoggedIn) {
      //const user = this.tokenStorageService.getUser();
      //this.roles = user.roles;
      //this.username = user.username;
    }
  }
  logout(): void {
    localStorage.removeItem("id_token");
    window.location.reload();
  }
}
