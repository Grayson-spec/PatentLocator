import { Component, OnInit } from '@angular/core';
import { SavedPatentService, SavedPatent } from '../../services/saved-patent.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {
  username: string = '';
  email: string = '';
  savedPatents: SavedPatent[] = [];
  noteCount: number = 0;

  constructor(private savedPatentService: SavedPatentService) {}

  ngOnInit(): void {
    const storedUser = localStorage.getItem('currentUser');
    if (storedUser) {
      const user = JSON.parse(storedUser);
      this.username = user.username;
      this.email = user.email;

      const userId = user.id;
      this.savedPatentService.getSavedPatents(userId).subscribe({
        next: (patents) => this.savedPatents = patents,
        error: (err) => console.error('Error fetching saved patents:', err)
      });
    }
  }

  signOut(): void {
    localStorage.removeItem('currentUser');
    window.location.href = '/login';
  }
}
