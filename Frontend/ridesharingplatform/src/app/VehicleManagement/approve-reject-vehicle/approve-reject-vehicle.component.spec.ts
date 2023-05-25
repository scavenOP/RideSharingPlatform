import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApproveRejectVehicleComponent } from './approve-reject-vehicle.component';

describe('ApproveRejectVehicleComponent', () => {
  let component: ApproveRejectVehicleComponent;
  let fixture: ComponentFixture<ApproveRejectVehicleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApproveRejectVehicleComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ApproveRejectVehicleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
