/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { StringsorderComponent } from './stringsorder.component';

describe('StringsorderComponent', () => {
  let component: StringsorderComponent;
  let fixture: ComponentFixture<StringsorderComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StringsorderComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StringsorderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
