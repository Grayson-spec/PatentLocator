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

  deleteSavedPatent(id: number): void {
    this.savedPatentService.deleteSavedPatent(id).subscribe({
      next: () => {
        this.savedPatents = this.savedPatents.filter(p => p.id !== id);
        alert('🗑️ Patent removed from your saved list.');
      },
      error: (err) => {
        console.error('Error removing saved patent:', err);
        alert('❌ Failed to remove patent.');
      }
    });
  }

  signOut(): void {
    localStorage.removeItem('currentUser');
    window.location.href = '/login';
  }
}
