import { TestBed } from '@angular/core/testing';

import { ApiService } from './api.service';

describe('ApiService', () => {
  let service: ApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('getAll should return list of items', (done: DoneFn) => {
    service.getAll().subscribe((value) =>{
      expect(value).toBeDefined();
      done();
    })
  });
});
