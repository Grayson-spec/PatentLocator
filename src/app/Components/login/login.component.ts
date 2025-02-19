import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  constructor(private router: Router) { }

  onSubmit(username: string, password: string): void {
    // Add login logic here
    console.log(username, password);
    this.router.navigate(['/home']);
  }

  goBack(): void {
    this.router.navigate(['/welcome']);
  }
}