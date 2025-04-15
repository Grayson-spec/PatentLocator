import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

interface Patent {
  id: number;
  patentNumber: string;
  title: string;
  inventor: string;
  publicationDate: string;
}

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  patents: Patent[] = [];
  allPatents: Patent[] = [];
  latestDate: string = '';

  constructor(private http: HttpClient, private router: Router) {}

  ngOnInit(): void {
    this.getPatents();
  }

  getPatents(): void {
    this.http.get<Patent[]>('http://localhost:5005/api/patents')
      .subscribe(response => {
        this.patents = response;
        this.allPatents = response;

        const latest = [...this.patents].sort((a, b) =>
          new Date(b.publicationDate).getTime() - new Date(a.publicationDate).getTime()
        )[0];
        this.latestDate = new Date(latest.publicationDate).toLocaleDateString();
      });
  }

  filterTable(event: Event): void {
    const value = (event.target as HTMLInputElement).value.toLowerCase();
    this.patents = this.allPatents.filter(p =>
      p.title.toLowerCase().includes(value) || p.inventor.toLowerCase().includes(value)
    );
  }

  goToPatentDetails(id: number): void {
    this.router.navigate(['/patent', id]);
  }
}
