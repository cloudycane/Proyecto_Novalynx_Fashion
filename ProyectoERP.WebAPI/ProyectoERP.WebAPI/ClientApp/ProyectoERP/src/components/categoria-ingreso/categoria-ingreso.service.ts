import { Injectable } from '@angular/core';
import { categoriaIngresoDTO } from './categoria-ingreso';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';

export interface CategoriaIngreso {
  id?: number;
  nombre: string;
  color: string; 
}

@Injectable({
  providedIn: 'root'
})
export class CategoriaIngresoService {
  constructor(private http : HttpClient) { }

  private apiUrl = "https://localhost:7256/api/CategoriaIngreso";

  obtenerTodos() : Observable<categoriaIngresoDTO[]>{
    return this.http.get<categoriaIngresoDTO[]>(this.apiUrl)
  }

  crearCategoria(categoria: CategoriaIngreso): Observable<CategoriaIngreso> {
    return this.http.post<CategoriaIngreso>(this.apiUrl, categoria);
  }
}
