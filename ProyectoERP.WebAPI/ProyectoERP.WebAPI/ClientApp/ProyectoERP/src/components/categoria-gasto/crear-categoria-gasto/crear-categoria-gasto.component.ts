import { ChangeDetectionStrategy, Component, inject, OnInit } from '@angular/core';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { ReactiveFormsModule, FormBuilder, FormGroup, FormControl, FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { Router, RouterModule } from '@angular/router';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import {
  MAT_DIALOG_DATA,
  MatDialogRef,
  MatDialogContent
} from '@angular/material/dialog';
import { NgxColorsModule } from 'ngx-colors';
import { MatIconModule } from '@angular/material/icon';
import { ColorPickerModule } from 'ngx-color-picker';
import { HttpClient } from '@angular/common/http';
import Swal from 'sweetalert2';
import { CategoriaGasto, CategoriaGastoService } from '../categoria-gasto.service';

@Component({
  selector: 'app-crear-categoria-gasto',
  imports: [SweetAlert2Module, MatIconModule, ColorPickerModule, ReactiveFormsModule, FormsModule, MatButtonModule,  RouterModule, MatFormFieldModule, MatInputModule, MatDialogContent, NgxColorsModule,  ],
  templateUrl: './crear-categoria-gasto.component.html',
  styleUrl: './crear-categoria-gasto.component.css'
})
export class CrearCategoriaGastoComponent implements OnInit {

  readonly dialogRef = inject(MatDialogRef<CrearCategoriaGastoComponent>);

  color: string = "#000000";
  categoria: CategoriaGasto = {
    nombre: '',
    color: '#000000'
  }
  constructor(private router: Router, private formBuilder: FormBuilder, private http: HttpClient, private categoriaService: CategoriaGastoService) { }

  form!: FormGroup;
  ngOnInit(): void {
    this.form = this.formBuilder.group({
      nombre: new FormControl(''),
      color: new FormControl('#000000')  // Add the color form control here
    });

    this.form.valueChanges.subscribe(values => {
      this.categoria = { ...this.categoria, ...values };
    });
  }

  onColorChange(newColor: string): void {
    this.color = newColor;  // Update component variable
    this.form.get('color')?.setValue(newColor);  // Update FormControl
    console.log("Color selected:", newColor);  }

  guardarCambios(): void {
    console.log("guardarCambios triggered!");

    // Get updated form values
    this.categoria.nombre = this.form.get('nombre')?.value;
    this.categoria.color = this.form.get('color')?.value; // Fetch color from form

    console.log("Data to be saved:", this.categoria);

    if (this.form.valid) {
      this.categoriaService.crearCategoria(this.categoria).subscribe(
        (response) => {
          console.log('Categoría guardada:', response);
          Swal.fire({
            icon: 'success',
            title: 'Categoría guardada',
            text: 'La categoría se ha guardado correctamente.',
            confirmButtonText: 'OK'
          });

        },
        (error) => {
          console.error('Error al guardar:', error);
          alert('Error al guardar la categoría.');
        }
      );
    } else {
      console.log("Formulario no válido");
    }
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

}
