import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { Router, RouterModule } from '@angular/router';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDialogRef } from '@angular/material/dialog';
import { NgxColorsModule } from 'ngx-colors';
import { MatIconModule } from '@angular/material/icon';
import { ColorPickerModule } from 'ngx-color-picker';

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
    NgxColorsModule,
    MatIconModule
  ],
  templateUrl: './crear-categoria-ingreso.component.html',
  styleUrls: ['./crear-categoria-ingreso.component.css']
})
export class CrearCategoriaIngresoComponent implements OnInit {
  readonly dialogRef = inject(MatDialogRef<CrearCategoriaIngresoComponent>);

  constructor(private router: Router, private formBuilder: FormBuilder) { }

  color: string = '#EC407A';
  form!: FormGroup;

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      nombre: new FormControl('')
    });
  }

  guardarCambios(): void {
    if (this.form.valid) {
      console.log("Form Data: ", this.form.value);
      this.router.navigate(['/categoriasIngreso']);
    }
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
