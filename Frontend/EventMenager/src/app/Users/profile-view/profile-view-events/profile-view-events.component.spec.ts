import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfileViewEventsComponent } from './profile-view-events.component';

describe('ProfileViewEventsComponent', () => {
  let component: ProfileViewEventsComponent;
  let fixture: ComponentFixture<ProfileViewEventsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProfileViewEventsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfileViewEventsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
