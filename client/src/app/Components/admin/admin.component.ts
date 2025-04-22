import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
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

  currentPage = 1;
  itemsPerPage = 50;

  constructor(private http: HttpClient, private router: Router) {
    console.log('🧠 AdminComponent.ts loaded');
  }

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

  get paginatedPatents(): Patent[] {
    const start = (this.currentPage - 1) * this.itemsPerPage;
    const end = start + this.itemsPerPage;
    return this.patents.slice(start, end);
  }

  nextPage(): void {
    if (this.currentPage * this.itemsPerPage < this.patents.length) {
      this.currentPage++;
    }
  }

  previousPage(): void {
    if (this.currentPage > 1) {
      this.currentPage--;
    }
  }

  filterTable(event: Event): void {
    const value = (event.target as HTMLInputElement).value.toLowerCase();
    this.patents = this.allPatents.filter(p =>
      p.title.toLowerCase().includes(value) || p.inventor.toLowerCase().includes(value)
    );
    this.currentPage = 1;
  }

  goToPatentDetails(id: number): void {
    this.router.navigate(['/patent', id]);
  }

  savePatent(patentId: number): void {
    console.log('🟡 savePatent() called with ID:', patentId);

    const currentUser = JSON.parse(localStorage.getItem('currentUser') || 'null');
    console.log('👤 Current user from localStorage:', currentUser);

    if (!currentUser || !currentUser.id) {
      alert('⚠️ You must be logged in to save patents.');
      return;
    }

    const payload = {
      userId: currentUser.id,
      patentId: patentId,
      savedDate: new Date().toISOString()
    };

    console.log('📦 Payload being sent to backend:', payload);

    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

    this.http.post('http://localhost:5005/api/users/saved', payload, { headers })
      .subscribe({
        next: () => {
          console.log('✅ Patent saved successfully!');
          alert('✅ Patent saved successfully!');
        },
        error: (err) => {
          console.error('❌ Save failed with error:', err);
          alert('❌ Failed to save patent.');
        }
      });
  }
}
