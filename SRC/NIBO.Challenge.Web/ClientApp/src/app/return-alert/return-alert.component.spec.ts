import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReturnAlertComponent } from './return-alert.component';

describe('ReturnAlertComponent', () => {
  let component: ReturnAlertComponent;
  let fixture: ComponentFixture<ReturnAlertComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReturnAlertComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReturnAlertComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
