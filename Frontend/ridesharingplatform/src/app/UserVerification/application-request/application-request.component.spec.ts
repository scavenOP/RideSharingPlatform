import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicationRequestComponent } from './application-request.component';

describe('ApplicationRequestComponent', () => {
  let component: ApplicationRequestComponent;
  let fixture: ComponentFixture<ApplicationRequestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApplicationRequestComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ApplicationRequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
