import { TestBed } from '@angular/core/testing';

import { UserPassService } from './user-pass.service';

describe('UserPassService', () => {
  let service: UserPassService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UserPassService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
