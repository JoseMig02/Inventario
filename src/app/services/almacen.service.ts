import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Almacen } from '../models/Almacen';

@Injectable({
  providedIn: 'root'
})
export class AlmacenService {
  private apiUrl = 'https://localhost:7092/api/Almacen';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Almacen[]> {
    return this.http.get<Almacen[]>(this.apiUrl);
  }

  getById(id: number): Observable<Almacen> {
    return this.http.get<Almacen>(`${this.apiUrl}/${id}`);
  }

  create(almacen: Almacen): Observable<Almacen> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<Almacen>(this.apiUrl, almacen, { headers });
  }

  update(id: number, almacen: Almacen): Observable<void> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.put<void>(`${this.apiUrl}/${id}`, almacen, { headers });
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
