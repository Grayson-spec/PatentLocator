import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent {


  constructor(private router: Router) { }


  goBack(): void {
    this.router.navigate(['/login']);
  }

  onSubmit(): void {
    this.router.navigate(['/home']);
  }

}