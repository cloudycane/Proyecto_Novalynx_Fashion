import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface Cuenta {
  id?: number;
  nombre: string;
  descripcion: string;
  color: string;
  fechaDeCreacion: Date;
}

@Injectable({
  providedIn: 'root'
})
export class CuentaService {
  constructor(private http: HttpClient) { }

  private apiUrl = "https://localhost:7256/api/Cuentas";

  crearCuenta(cuenta: Cuenta): Observable<Cuenta> {
    return this.http.post<Cuenta>(this.apiUrl, cuenta);
  }
}
