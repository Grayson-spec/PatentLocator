import { Component, ElementRef } from '@angular/core';
import { PatentService } from './patent.service';


@Component({
  selector: 'app-patent',
  templateUrl: './patentdetails.component.html',
  styleUrls: ['./patentdetails.component.css']
})
// Attempted to attach api here. Will need to revisit later. 
export class PatentdetailsComponent {
  query = ''
  patentResults = [];

  constructor(private patentService: PatentService, private elementRef: ElementRef) { }
}