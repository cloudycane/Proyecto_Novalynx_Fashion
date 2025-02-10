import { TestBed } from '@angular/core/testing';

import { CategoriaGastoService } from './categoria-gasto.service';

describe('CategoriaGastoService', () => {
  let service: CategoriaGastoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CategoriaGastoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
