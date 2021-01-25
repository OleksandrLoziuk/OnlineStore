/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { StringsOrderService } from './strings-order.service';

describe('Service: StringsOrder', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [StringsOrderService]
    });
  });

  it('should ...', inject([StringsOrderService], (service: StringsOrderService) => {
    expect(service).toBeTruthy();
  }));
});
