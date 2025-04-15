// patent.service.ts
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError, throwError, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PatentService {

  private apiKey = '';
  private apiUrl = ''; // external API URL if used

  constructor(private http: HttpClient) {}

  // 🔍 Used for searching patents externally
  searchPatents(query: string) {
    const params = {
      engine: 'google_patents',
      q: query,
      api_key: this.apiKey,
      output: 'json'
    };

    return this.http.get(this.apiUrl, { params, responseType: 'text' }).pipe(
      catchError((error: HttpErrorResponse) => {
        console.error('Error occurred:', error);
        return throwError(() => error);
      })
    );
  }

  // ✅ Used for retrieving a specific patent by ID from your local backend
  getPatentById(id: number): Observable<any> {
    return this.http.get<any>(`http://localhost:5005/api/patents/${id}`).pipe(
      catchError((error: HttpErrorResponse) => {
        console.error('Error fetching patent by ID:', error);
        return throwError(() => error);
      })
    );
  }
}
