import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyVehicleComponent } from './my-vehicle.component';

describe('MyVehicleComponent', () => {
  let component: MyVehicleComponent;
  let fixture: ComponentFixture<MyVehicleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MyVehicleComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MyVehicleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
