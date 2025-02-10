import { TestBed } from '@angular/core/testing';

import { SuministradorService } from './suministrador.service';

describe('SuministradorService', () => {
  let service: SuministradorService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SuministradorService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
