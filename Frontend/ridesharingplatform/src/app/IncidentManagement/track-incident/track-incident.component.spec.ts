import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrackIncidentComponent } from './track-incident.component';

describe('TrackIncidentComponent', () => {
  let component: TrackIncidentComponent;
  let fixture: ComponentFixture<TrackIncidentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TrackIncidentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TrackIncidentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
