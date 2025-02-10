import { AfterViewInit, Component, OnInit, ViewChild, inject } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatCardModule } from '@angular/material/card';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule, provideNativeDateAdapter } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatTabsModule } from '@angular/material/tabs';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';  // ✅ Added missing import
import { CategoriaIngreso, CategoriaIngresoService } from '../categoria-ingreso/categoria-ingreso.service';
import { CrearCategoriaIngresoComponent } from '../categoria-ingreso/crear-categoria-ingreso/crear-categoria-ingreso.component';
import { CrearCategoriaGastoComponent } from '../categoria-gasto/crear-categoria-gasto/crear-categoria-gasto.component';
import { CategoriaGasto, CategoriaGastoService } from '../categoria-gasto/categoria-gasto.service';
import { CuentaComponent } from '../cuenta/cuenta.component';
import { CrearCuentaComponent } from '../cuenta/crear-cuenta/crear-cuenta.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    CommonModule,
    MatMenuModule,
    ReactiveFormsModule,
    MatNativeDateModule,
    MatDatepickerModule,
    MatCardModule,
    MatProgressBarModule,
    MatButtonToggleModule,
    MatButtonModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
    MatDialogModule,
    MatTabsModule,
    MatPaginatorModule,
    MatTableModule 
  ],
  providers: [provideNativeDateAdapter()],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['nombre', 'color'];
  displayedColumnsCategoriaGasto: string[] = ['nombre', 'color'];
  dataSource = new MatTableDataSource<CategoriaIngreso>();
  dataSourceGasto = new MatTableDataSource<CategoriaGasto>();

  @ViewChild('paginatorIngreso', { static: true }) paginatorIngreso!: MatPaginator;
  @ViewChild('paginatorGasto', { static: true }) paginatorGasto!: MatPaginator;

  categorias: CategoriaIngreso[] = [];
  categoriasGasto: CategoriaGasto[] = []; 
  categoriaIngresoService = inject(CategoriaIngresoService);
  categoriaGastoService = inject(CategoriaGastoService);

  dialog = inject(MatDialog); 

  ngOnInit(): void {
    this.cargarCategorias();
    this.cargarCategoriasGasto();
  }

  ngAfterViewInit() {
    setTimeout(() => {
      if (this.paginatorIngreso) {
        this.dataSource.paginator = this.paginatorIngreso;
      }
      if (this.paginatorGasto) {
        this.dataSourceGasto.paginator = this.paginatorGasto;
      }
    });
  }


  cargarCategorias(): void {
    this.categoriaIngresoService.obtenerTodos().subscribe(
      (data) => {
        this.categorias = data;
        this.dataSource.data = this.categorias; 
        console.log("📌 Categorías obtenidas:", this.categorias);
      },
      (error) => {
        console.error("⚠️ Error al obtener categorías:", error);
      }
    );
  }

  cargarCategoriasGasto(): void {
    this.categoriaGastoService.obtenerTodos().subscribe(
      (data) => {
        this.categoriasGasto = data;
        this.dataSourceGasto.data = this.categoriasGasto;

        console.log("📌 Categorías obtenidas:", this.categoriasGasto);
      },
      (error) => {
        console.error("⚠️ Error al obtener categorías:", error);
      }
    );

  }

  openDialog(): void {
    const dialogRef = this.dialog.open(CrearCategoriaIngresoComponent);

    dialogRef.afterClosed().subscribe(() => {
      this.cargarCategorias(); 
    });
  }

  openDialogCategoriaGasto(): void {
    const dialogRef = this.dialog.open(CrearCategoriaGastoComponent);

    dialogRef.afterClosed().subscribe(() => {
      this.cargarCategoriasGasto();
    });
  }

  openDialogCuenta(): void {
    const dialogRef = this.dialog.open(CrearCuentaComponent);

    dialogRef.afterClosed().subscribe(() => {
     // this.cargarCategoriasGasto();
    });
  }
}
