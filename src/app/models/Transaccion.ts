export interface Transaccion {
    id?: number;
    tipoTransaccion: string;
    idArticulo: number;
    fecha: Date;
    cantidad: number;
    costo: number;
    observaciones: string;
  }
  