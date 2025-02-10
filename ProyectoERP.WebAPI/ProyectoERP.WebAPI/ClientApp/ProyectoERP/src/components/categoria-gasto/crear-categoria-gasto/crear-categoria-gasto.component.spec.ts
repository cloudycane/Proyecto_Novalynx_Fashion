import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CrearCategoriaGastoComponent } from './crear-categoria-gasto.component';

describe('CrearCategoriaGastoComponent', () => {
  let component: CrearCategoriaGastoComponent;
  let fixture: ComponentFixture<CrearCategoriaGastoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CrearCategoriaGastoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CrearCategoriaGastoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
