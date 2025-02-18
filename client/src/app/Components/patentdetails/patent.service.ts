// patent.service.ts
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

/*
* Errors here in getting the api endpoint in. CORS policy caused error and
* the proper data format isnt coming through. 
*/
export class PatentService {

  private apiKey = ''
  private apiUrl = ''; 

  constructor(private http: HttpClient) { }

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
}