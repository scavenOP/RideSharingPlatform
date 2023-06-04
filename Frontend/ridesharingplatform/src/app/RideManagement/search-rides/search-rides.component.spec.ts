import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchRidesComponent } from './search-rides.component';

describe('SearchRidesComponent', () => {
  let component: SearchRidesComponent;
  let fixture: ComponentFixture<SearchRidesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchRidesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SearchRidesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
