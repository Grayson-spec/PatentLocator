import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PatentService } from './patent.service';
import { SavedPatentService, SavedPatent } from '../../services/saved-patent.service';

@Component({
  selector: 'app-patent',
  templateUrl: './patentdetails.component.html',
  styleUrls: ['./patentdetails.component.css']
})
export class PatentdetailsComponent implements OnInit {
  selectedPatent: any = {
    id: 0,
    patentNumber: '',
    title: '',
    inventor: '',
    publicationDate: '',
    description: ''
  };

  constructor(
    private route: ActivatedRoute,
    private patentService: PatentService,
    private savedPatentService: SavedPatentService
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.patentService.getPatentById(+id).subscribe({
        next: (patent) => {
          this.selectedPatent = patent;
        },
        error: (err) => {
          console.error('Failed to load patent:', err);
        }
      });
    }
  }

  savePatent(): void {
    const currentUser = localStorage.getItem('currentUser');
    if (!currentUser) {
      alert('⚠️ You must be logged in to save patents.');
      return;
    }

    const user = JSON.parse(currentUser);
    const savedPatent: SavedPatent = {
      id: 0,
      userId: user.id,
      patentId: this.selectedPatent.id,
      savedDate: new Date().toISOString()
    };

    this.savedPatentService.addSavedPatent(savedPatent).subscribe({
      next: () => {
        alert('✅ Patent saved to your account!');
      },
      error: (err) => {
        console.error('❌ Error saving patent:', err);
        alert('Something went wrong saving this patent.');
      }
    });
  }
}
