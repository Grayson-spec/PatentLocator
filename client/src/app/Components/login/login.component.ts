import { Component } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule, HttpClientModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  username = '';
  password = '';
  errorMessage = '';

  constructor(private http: HttpClient, private router: Router) {}

  onSubmit(): void {
    const loginData = {
      username: this.username,
      password: this.password,
      email: '',  // Placeholder to satisfy model
      role: ''    // Placeholder to satisfy model
    };

    this.http.post<any>('http://localhost:5005/api/users/login', loginData).subscribe({
      next: (user) => {
        localStorage.setItem('currentUser', JSON.stringify(user));
        this.router.navigate(['/account']);
      },
      error: (err) => {
        console.error('Login error:', err);
        this.errorMessage = 'Invalid credentials. Please try again.';
      }
    });
  }

  goBack(): void {
    this.router.navigate(['/welcome']);
  }
}
