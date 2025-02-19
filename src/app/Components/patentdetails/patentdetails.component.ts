// Import necessary modules
import { Component, ElementRef } from '@angular/core';

// Define the Patent interface
interface Patent {
  title: string;
  number: string;
  filingDate: string;
  issueDate: string;
  inventors: string[];
  description: string;
  claims: string[];
  citations: string[];
}

// Define the PatentComponent
@Component({
  selector: 'app-patent',
  templateUrl: './patentdetails.component.html',
  styleUrls: ['./patentdetails.component.css']
})
export class PatentdetailsComponent {
  // Patent data
  patent: Patent = {
    title: 'Sample Patent Title',
    number: 'US1234567B2',
    filingDate: '2020-01-01',
    issueDate: '2022-01-01',
    inventors: ['John Doe', 'Jane Smith'],
    description: 'This is a sample patent description.',
    claims: [
      'A method for manufacturing a sample product.',
      'A system for using the sample product.'
    ],
    citations: [
      'US9876543B1',
      'US1111111A1'
    ]
  };

  // Constructor
  constructor(private elementRef: ElementRef) {}

  // Lifecycle hook: AfterViewInit
  ngAfterViewInit(): void {
    // Get the HTML elements
    const patentTitleElement = this.elementRef.nativeElement.querySelector('#patent-title');
    const patentNumberElement = this.elementRef.nativeElement.querySelector('#patent-number');
    const filingDateElement = this.elementRef.nativeElement.querySelector('#filing-date');
    const issueDateElement = this.elementRef.nativeElement.querySelector('#issue-date');
    const inventorsElement = this.elementRef.nativeElement.querySelector('#inventors');
    const patentDescriptionElement = this.elementRef.nativeElement.querySelector('#patent-description');
    const patentClaimsElement = this.elementRef.nativeElement.querySelector('#patent-claims');
    const patentCitationsElement = this.elementRef.nativeElement.querySelector('#patent-citations');

    // Populate the patent information
    patentTitleElement.textContent = this.patent.title;
    patentNumberElement.textContent = this.patent.number;
    filingDateElement.textContent = this.patent.filingDate;
    issueDateElement.textContent = this.patent.issueDate;
    inventorsElement.textContent = this.patent.inventors.join(', ');
    patentDescriptionElement.textContent = this.patent.description;

    // Create and append claim list items
    this.patent.claims.forEach((claim) => {
      const claimListItem = document.createElement('li');
      claimListItem.textContent = claim;
      patentClaimsElement.appendChild(claimListItem);
    });

    // Create and append citation list items
    this.patent.citations.forEach((citation) => {
      const citationListItem = document.createElement('li');
      citationListItem.textContent = citation;
      patentCitationsElement.appendChild(citationListItem);
    });
  }
}