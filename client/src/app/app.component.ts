import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit{
  // title = 'Dating app'; // * inferred type
  title: string = 'Dating app'; // declared type
  users: any; // * considered a bad practice to use any
  
  constructor(private http: HttpClient) {} // dependency injection
  ngOnInit() {
    // This code executes after the component finish mounting
    this.http.get('https://localhost:5001/api/users').subscribe({
      next: response => this.users = response,
      error: (error) => console.log(error),
      complete: () => console.log('Request has completed')
    });
  }
}
