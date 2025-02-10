import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SuministradorComponent } from './suministrador.component';

describe('SuministradorComponent', () => {
  let component: SuministradorComponent;
  let fixture: ComponentFixture<SuministradorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SuministradorComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SuministradorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
