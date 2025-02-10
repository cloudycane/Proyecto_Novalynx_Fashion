import { TestBed } from '@angular/core/testing';

import { CategoriaIngresoService } from './categoria-ingreso.service';

describe('CategoriaIngresoService', () => {
  let service: CategoriaIngresoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CategoriaIngresoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
