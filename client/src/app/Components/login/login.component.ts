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
    const user = { Username: username, Password: password };
    this.http.post('http://localhost:5005/api/users', user)
      .subscribe((response: any) => {
        this.isValid = response.isValid;
        if (this.isValid) {
          console.log(username, password);
          this.router.navigate(['/home']);
        } else {
          console.log("error");
        }
      });
  }

  
  goBack(): void {
    this.router.navigate(['/welcome']);
  }
}