import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ScheduleRideComponent } from './schedule-ride.component';

describe('ScheduleRideComponent', () => {
  let component: ScheduleRideComponent;
  let fixture: ComponentFixture<ScheduleRideComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ScheduleRideComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ScheduleRideComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
