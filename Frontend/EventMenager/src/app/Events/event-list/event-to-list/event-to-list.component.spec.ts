import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EventToListComponent } from './event-to-list.component';

describe('EventToListComponent', () => {
  let component: EventToListComponent;
  let fixture: ComponentFixture<EventToListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EventToListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EventToListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
