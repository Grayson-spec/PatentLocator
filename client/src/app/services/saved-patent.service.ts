import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface SavedPatent {
  id: number;
  userId: number;
  patentNumber: string;
  title: string;
  inventor: string;
  publicationDate: string;
}

@Injectable({
  providedIn: 'root'
})
export class SavedPatentService {
  private apiUrl = 'http://localhost:5005/api/savedpatents';

  constructor(private http: HttpClient) {}

  getSavedPatents(userId: number): Observable<SavedPatent[]> {
    return this.http.get<SavedPatent[]>(`${this.apiUrl}/user/${userId}`);
  }

  addSavedPatent(savedPatent: SavedPatent): Observable<any> {
    return this.http.post(this.apiUrl, savedPatent);
  }

  deleteSavedPatent(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
