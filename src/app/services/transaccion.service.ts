import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Transaccion } from '../models/Transaccion';

@Injectable({
  providedIn: 'root'
})
export class TransaccionService {

  private apiUrl: string = 'https://localhost:7092/api/Transacciones';

  constructor(private http: HttpClient) { }

  getTransacciones(): Observable<Transaccion[]> {
    return this.http.get<Transaccion[]>(this.apiUrl);
  }

  getTransaccion(id: number): Observable<Transaccion> {
    return this.http.get<Transaccion>(`${this.apiUrl}/${id}`);
  }

  createTransaccion(transaccion: Transaccion): Observable<Transaccion> {
    return this.http.post<Transaccion>(this.apiUrl, transaccion);
  }

  updateTransaccion(id: number, transaccion: Transaccion): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, transaccion);
  }

  deleteTransaccion(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
