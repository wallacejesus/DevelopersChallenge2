import { TestBed, inject } from '@angular/core/testing';

import { ViewDetailService } from './view-detail.service';

describe('ViewDetailService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ViewDetailService]
    });
  });

  it('should be created', inject([ViewDetailService], (service: ViewDetailService) => {
    expect(service).toBeTruthy();
  }));
});
