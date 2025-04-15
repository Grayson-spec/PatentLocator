import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  formData!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private http: HttpClient,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.formData = this.fb.group({
      username: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
      role: ['user', Validators.required]
    });
  }

  getPasswordStrength(password: string): string {
    if (password.length < 6) return 'Weak';
    if (password.length < 10) return 'Medium';
    return 'Strong';
  }

  onSubmit(): void {
    if (this.formData.valid) {
      const user = this.formData.value;

      // ✅ First, check if the user already exists
      this.http.get<any[]>('http://localhost:5005/api/users').subscribe({
        next: (users) => {
          const existingUser = users.find(u => u.email === user.email || u.username === user.username);
          if (existingUser) {
            alert('An account with this email or username already exists.');
          } else {
            // ✅ Proceed to create the new user
            this.http.post('http://localhost:5005/api/users', user).subscribe({
              next: (createdUser: any) => {
                alert('Account created!');
                localStorage.setItem('currentUser', JSON.stringify(createdUser));
                this.router.navigate(['/account']);
              },
              error: (err) => {
                console.error('Signup error:', err);
                alert('Something went wrong. Please try again.');
              }
            });
          }
        },
        error: (err) => {
          console.error('Error checking existing users:', err);
          alert('Unable to verify existing accounts. Please try again later.');
        }
      });
    }
  }

  goBack(): void {
    this.router.navigate(['/home']);
  }
}
