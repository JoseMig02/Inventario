import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Articulo } from '../models/Articulo';

@Injectable({
  providedIn: 'root'
})
export class ArticuloService {
    private apiUrl = 'https://localhost:7092/api/Articulos'

  constructor(private http: HttpClient) {}
  getArticulos(): Observable<Articulo[]> {
    return this.http.get<Articulo[]>(this.apiUrl);
  }

  getArticulo(id: string): Observable<Articulo> {
    return this.http.get<Articulo>(`${this.apiUrl}/${id}`);
  }

  createArticulo(Articulo: Articulo): Observable<Articulo> {
    return this.http.post<Articulo>(this.apiUrl, Articulo);
  }

  updateArticulo(id:number,Articulo: Articulo): Observable<Articulo> {
    return this.http.put<Articulo>(`${this.apiUrl}/${id}`, Articulo);
  }

  deleteArticulo(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
