// src/app/services/tipo-inventario.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TipoInventario } from '../models/TipoInventario';

@Injectable({
  providedIn: 'root'
})
export class TipoInventarioService {
  private apiUrl = 'https://localhost:7092/api/TipoInventario'

  constructor(private http: HttpClient) {}

  getTipoInventarios(): Observable<TipoInventario[]> {
    return this.http.get<TipoInventario[]>(this.apiUrl);
  }

  getTipoInventario(id: string): Observable<TipoInventario> {
    return this.http.get<TipoInventario>(`${this.apiUrl}/${id}`);
  }

  createTipoInventario(tipoInventario: TipoInventario): Observable<TipoInventario> {
    return this.http.post<TipoInventario>(this.apiUrl, tipoInventario);
  }

  updateTipoInventario(id:number,tipoInventario: TipoInventario): Observable<TipoInventario> {
    return this.http.put<TipoInventario>(`${this.apiUrl}/${id}`, tipoInventario);
  }

  deleteTipoInventario(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
