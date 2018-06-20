import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { THIRDComponent } from './third.component';

describe('THIRDComponent', () => {
  let component: THIRDComponent;
  let fixture: ComponentFixture<THIRDComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ THIRDComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(THIRDComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
