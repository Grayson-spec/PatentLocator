import { TestBed } from '@angular/core/testing';

import { SavedPatentService } from './saved-patent.service';

describe('SavedPatentService', () => {
  let service: SavedPatentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SavedPatentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
