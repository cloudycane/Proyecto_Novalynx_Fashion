import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductoSuministradorComponent } from './producto-suministrador.component';

describe('ProductoSuministradorComponent', () => {
  let component: ProductoSuministradorComponent;
  let fixture: ComponentFixture<ProductoSuministradorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProductoSuministradorComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductoSuministradorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
