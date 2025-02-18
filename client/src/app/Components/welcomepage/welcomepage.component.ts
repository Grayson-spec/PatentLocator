import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-welcomepage',
  standalone: true,
  imports: [],
  templateUrl: './welcomepage.component.html',
  styleUrl: './welcomepage.component.css'
})
export class WelcomepageComponent {
  constructor(private router: Router) { }

  navigateToLogin() {
    this.router.navigate(['/login']);
  }

  navigateToSignup() {
    this.router.navigate(['/signup']);
  }
}
