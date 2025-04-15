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
    const userId = 1; // Placeholder for real user ID when auth is added

    const savedPatent: SavedPatent = {
      id: 0,
      userId: userId,
      patentNumber: this.selectedPatent.patentNumber,
      title: this.selectedPatent.title,
      inventor: this.selectedPatent.inventor,
      publicationDate: this.selectedPatent.publicationDate
    };

    this.savedPatentService.addSavedPatent(savedPatent).subscribe({
      next: () => {
        alert('Patent saved to your account!');
      },
      error: (err) => {
        console.error('Error saving patent:', err);
        alert('Something went wrong saving this patent.');
      }
    });
  }
}
