import { TestBed } from '@angular/core/testing';

import { EmpserviveService } from './empservive.service';

describe('EmpserviveService', () => {
  let service: EmpserviveService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EmpserviveService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
