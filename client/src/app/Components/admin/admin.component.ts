import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';

interface Patent {
  id: number;
  patentNumber: string;
  title: string;
  inventor: string;
  publicationDate: string;
}

@Component({
  selector: 'app-admin',
  standalone: true,
  imports: [HttpClientModule],
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  patents: Patent[] = [];
  allPatents: Patent[] = [];
  latestDate: string = '';

  constructor(private http: HttpClient) {}

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

        const tableBody = document.getElementById('table-body');
        if (tableBody) {
          tableBody.innerHTML = '';
          this.patents.forEach((patent: Patent) => {
            const row = `
              <tr>
                <td>${patent.id}</td>
                <td>${patent.patentNumber}</td>
                <td>${patent.title}</td>
                <td>${patent.inventor}</td>
                <td>${new Date(patent.publicationDate).toLocaleDateString()}</td>
              </tr>
            `;
            tableBody.innerHTML += row;
          });
        } else {
          console.error('Table body not found');
        }
      });
  }

  filterTable(event: Event): void {
    const value = (event.target as HTMLInputElement).value.toLowerCase();
    const filtered = this.allPatents.filter(p =>
      p.title.toLowerCase().includes(value) || p.inventor.toLowerCase().includes(value)
    );
    this.patents = filtered;

    const tableBody = document.getElementById('table-body');
    if (tableBody) {
      tableBody.innerHTML = '';
      filtered.forEach((patent: Patent) => {
        const row = `
          <tr>
            <td>${patent.id}</td>
            <td>${patent.patentNumber}</td>
            <td>${patent.title}</td>
            <td>${patent.inventor}</td>
            <td>${new Date(patent.publicationDate).toLocaleDateString()}</td>
          </tr>
        `;
        tableBody.innerHTML += row;
      });
    }
  }
}
