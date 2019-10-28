/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ClickService } from './click.service';

describe('Service: Click', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ClickService]
    });
  });

  it('should ...', inject([ClickService], (service: ClickService) => {
    expect(service).toBeTruthy();
  }));
});
