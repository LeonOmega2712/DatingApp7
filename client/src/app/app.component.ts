import { Component, OnInit } from '@angular/core';
import { AccountService } from './services/account.service';
import { User } from './models/user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  // title = 'Dating app'; // * inferred type
  title: string = 'Dating app'; // declared type
  // users: any; // * considered a bad practice to use any

  constructor(
    private accountService: AccountService
  ) {} // dependency injection
  ngOnInit() {
    // This code executes after the component finish mounting
    // this.getUsers();
    this.setCurrentUser();
  }

  setCurrentUser() {
    // const user: User = JSON.parse(localStorage.getItem('user')!)
    const userString = localStorage.getItem('user');
    if (!userString) {
      return;
    }
    const user: User = JSON.parse(userString);
    this.accountService.setCurrentUser(user);
  }
}
