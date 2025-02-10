import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { categoriaIngresoDTO } from '../categoria-ingreso/categoria-ingreso';
import { Observable } from 'rxjs';
import { categoriaGastoDTO } from './categoria-gasto';

export interface CategoriaGasto {
  id?: number;
  nombre: string;
  color: string;
}

@Injectable({
  providedIn: 'root'
})
export class CategoriaGastoService {
  constructor(private http: HttpClient) { }

  private apiUrl = "https://localhost:7256/api/CategoriaGasto";

  obtenerTodos(): Observable<categoriaGastoDTO[]> {
    return this.http.get<categoriaIngresoDTO[]>(this.apiUrl)
  }

  crearCategoria(categoria: CategoriaGasto): Observable<CategoriaGasto> {
    return this.http.post<CategoriaGasto>(this.apiUrl, categoria);
  }
}


