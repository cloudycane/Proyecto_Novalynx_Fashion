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
import { CategoriaIngreso, CategoriaIngresoService } from '../categoria-ingreso.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-crear-categoria-ingreso',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    ColorPickerModule,
    MatButtonModule,
    RouterModule,
    MatFormFieldModule,
    MatInputModule,
    MatDialogContent,
    NgxColorsModule,
    MatIconModule,
    FormsModule


  ],
  templateUrl: './crear-categoria-ingreso.component.html',
  styleUrls: ['./crear-categoria-ingreso.component.css']
})
export class CrearCategoriaIngresoComponent implements OnInit {
  readonly dialogRef = inject(MatDialogRef<CrearCategoriaIngresoComponent>);

  color: string = "#000000";
  categoria: CategoriaIngreso = {
    nombre: '',
    color: '#000000'
  }
  constructor(private router: Router, private formBuilder: FormBuilder, private http: HttpClient, private categoriaService: CategoriaIngresoService) { }
 
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


  guardarDatos() {
    
    this.categoria.color = this.form.get('color')?.value; // Get the color value from the form
    this.categoria.nombre = this.form.get('nombre')?.value; // Get the name value from the form

    // Submit the form data
    this.categoriaService.crearCategoria(this.categoria).subscribe(response => {
      console.log('Categoría guardada:', response);
      alert('Categoría guardada exitosamente!');
    }, error => {
      console.error('Error al guardar:', error);
      alert('Error al guardar la categoría.');
    });
  }

  onColorChange(newColor: string): void {
    this.color = newColor;  
    this.form.get('color')?.setValue(newColor);  
    console.log("Color selected:", newColor);
  }

  guardarCambios(): void {
    console.log("guardarCambios triggered!");

    this.categoria.nombre = this.form.get('nombre')?.value;
    this.categoria.color = this.form.get('color')?.value; 

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
