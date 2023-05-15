import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewapplicationComponent } from './newapplication.component';

describe('NewapplicationComponent', () => {
  let component: NewapplicationComponent;
  let fixture: ComponentFixture<NewapplicationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewapplicationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NewapplicationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
