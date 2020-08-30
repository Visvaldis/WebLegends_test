import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FacilityRowComponent } from './facility-row.component';

describe('FacilityRowComponent', () => {
  let component: FacilityRowComponent;
  let fixture: ComponentFixture<FacilityRowComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [FacilityRowComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FacilityRowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
