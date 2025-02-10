import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IndiceCategoriaGastoComponent } from './indice-categoria-gasto.component';

describe('IndiceCategoriaGastoComponent', () => {
  let component: IndiceCategoriaGastoComponent;
  let fixture: ComponentFixture<IndiceCategoriaGastoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [IndiceCategoriaGastoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(IndiceCategoriaGastoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
