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
import { Cuenta, CuentaService } from '../cuenta.service';
@Component({
  selector: 'app-crear-cuenta',
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
  templateUrl: './crear-cuenta.component.html',
  styleUrl: './crear-cuenta.component.css'
})
export class CrearCuentaComponent implements OnInit {
  readonly dialogRef = inject(MatDialogRef<CrearCuentaComponent>);

  color: string = "#000000";
  cuenta: Cuenta = {
    nombre: '',
    color: '#000000',
    descripcion: '',
    fechaDeCreacion: new Date()
  }
  constructor(private router: Router, private formBuilder: FormBuilder, private http: HttpClient, private cuentaService: CuentaService) { }
  form!: FormGroup;
  ngOnInit(): void {
    this.form = this.formBuilder.group({
      nombreCuenta: new FormControl(''),
      descripcion: new FormControl(''),
      color: new FormControl('#000000'),
      fechaDeCreacion: new FormControl(new Date().toISOString().split('T')[0]) // Default to today's date
    });


    this.form.valueChanges.subscribe(values => {
      this.cuenta = { ...this.cuenta, ...values };
    });
  }


  guardarDatos() {

    this.cuenta.color = this.form.get('color')?.value; // Get the color value from the form
    this.cuenta.nombre = this.form.get('nombre')?.value; // Get the name value from the form

    // Submit the form data
    this.cuentaService.crearCuenta(this.cuenta).subscribe(response => {
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

    this.cuenta.nombre = this.form.get('nombre')?.value;
    this.cuenta.descripcion = this.form.get('descripcion')?.value;
    this.cuenta.fechaDeCreacion = this.form.get('fechaDeCreacion')?.value;
    this.cuenta.color = this.form.get('color')?.value;

    console.log("Data to be saved:", this.cuenta);

    if (this.form.valid) {
      this.cuentaService.crearCuenta(this.cuenta).subscribe(
        (response) => {
          console.log('Cuenta guardada:', response);
          Swal.fire({
            icon: 'success',
            title: 'Cuenta guardada',
            text: 'La cuenta se ha guardado correctamente.',
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
