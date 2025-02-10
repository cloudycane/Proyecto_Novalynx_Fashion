import { Routes } from '@angular/router';
import { IndiceCategoriaIngresoComponent } from '../components/categoria-ingreso/indice-categoria-ingreso/indice-categoria-ingreso.component';
import { CrearCategoriaIngresoComponent } from '../components/categoria-ingreso/crear-categoria-ingreso/crear-categoria-ingreso.component';
import { HomeComponent } from '../components/home/home.component';

export const routes: Routes = [
  {
        path: '', component: HomeComponent
  },
  {
        path: 'categoriasIngreso', component: IndiceCategoriaIngresoComponent
  },
  {
        path: 'crearCategoriaIngreso', component: CrearCategoriaIngresoComponent
  }
];
