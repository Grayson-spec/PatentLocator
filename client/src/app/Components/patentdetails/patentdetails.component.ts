// patentdetails.component.ts
import { Component, ElementRef } from '@angular/core';
import { PatentService } from './patent.service';


@Component({
  selector: 'app-patent',
  templateUrl: './patentdetails.component.html',
  styleUrls: ['./patentdetails.component.css']
})
export class PatentdetailsComponent {
  query = ''
  patentResults = [];

  constructor(private patentService: PatentService, private elementRef: ElementRef) { }

  searchPatents() {
    this.patentService.searchPatents(this.query).subscribe({
      next: (response: string) => {
        console.log('Response:', response);
        // Handle the response as HTML
        const parser = new DOMParser();
        const doc = parser.parseFromString(response, 'text/html');
        // Parse the HTML document to extract relevant information
      },
      error: (error: any) => {
        console.error('Error searching patents:', error);
      }
    });
  }

  displayPatentResults() {
    const patentResultsList = this.elementRef.nativeElement.querySelector('#patent-results-list');
    patentResultsList.innerHTML = '';

    this.patentResults.forEach((result) => {
      const listItem = document.createElement('li');
      listItem.textContent = (result as any).title;
      patentResultsList.appendChild(listItem);
    });
  }
}