import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IndiceCategoriaIngresoComponent } from './indice-categoria-ingreso.component';

describe('IndiceCategoriaIngresoComponent', () => {
  let component: IndiceCategoriaIngresoComponent;
  let fixture: ComponentFixture<IndiceCategoriaIngresoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [IndiceCategoriaIngresoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(IndiceCategoriaIngresoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
