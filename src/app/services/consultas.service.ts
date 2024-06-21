import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ConsultasService {
    private apiUrl = 'https://localhost:7092/api';

  constructor(private http: HttpClient) { }

  filtrarPorArticulo(idArticulo: number): Observable<any> {
    let params = new HttpParams()
      .set('idArticulo', idArticulo.toString());

    return this.http.get<any>(`${this.apiUrl}/consultas/porArticulo`, { params: params });
  }

  filtrarPorRangoFechas(fechaInicio: Date, fechaFin: Date): Observable<any> {
    let params = new HttpParams()
      .set('fechaInicio', fechaInicio.toISOString())
      .set('fechaFin', fechaFin.toISOString());

    return this.http.get<any>(`${this.apiUrl}/consultas/porRangoFechas`, { params: params });
  }
}
