import { TestBed, inject } from '@angular/core/testing';

import { ImportFilesService } from './import-files.service';

describe('ImportFilesService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ImportFilesService]
    });
  });

  it('should be created', inject([ImportFilesService], (service: ImportFilesService) => {
    expect(service).toBeTruthy();
  }));
});
