import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BikeTypeComponent } from './bike-type.component';

describe('BikeTypeComponent', () => {
  let component: BikeTypeComponent;
  let fixture: ComponentFixture<BikeTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BikeTypeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BikeTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
