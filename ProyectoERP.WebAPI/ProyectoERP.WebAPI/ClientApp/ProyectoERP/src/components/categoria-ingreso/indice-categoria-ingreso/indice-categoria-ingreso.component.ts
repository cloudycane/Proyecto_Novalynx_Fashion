import { Component, OnInit } from '@angular/core';
import { CategoriaIngresoService } from '../categoria-ingreso.service';

@Component({
  selector: 'app-indice-categoria-ingreso',
  imports: [],
  templateUrl: './indice-categoria-ingreso.component.html',
  styleUrl: './indice-categoria-ingreso.component.css'
})
export class IndiceCategoriaIngresoComponent implements OnInit {

  constructor(private categoriaIngresoService : CategoriaIngresoService){}

  ngOnInit(): void {
    this.categoriaIngresoService.obtenerTodos()
    .subscribe(categoriasIngreso =>{
      console.log(categoriasIngreso);
    }, error => console.error(error));
    
  }
}
