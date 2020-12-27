/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ReceiptService } from './receipt.service';

describe('Service: Receipt', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ReceiptService]
    });
  });

  it('should ...', inject([ReceiptService], (service: ReceiptService) => {
    expect(service).toBeTruthy();
  }));
});
