import { TestBed } from '@angular/core/testing';

import { ProductoSuministradorService } from './producto-suministrador.service';

describe('ProductoSuministradorService', () => {
  let service: ProductoSuministradorService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProductoSuministradorService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
