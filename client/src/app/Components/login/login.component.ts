import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  username = '';
  password = '';
  isValid = false;

  constructor(private router: Router, private http: HttpClient) { }

  onSubmit(username: string, password: string): void {
          console.log(username, password);
          this.router.navigate(['/home']);
  }

  
  goBack(): void {
    this.router.navigate(['/welcome']);
  }
}