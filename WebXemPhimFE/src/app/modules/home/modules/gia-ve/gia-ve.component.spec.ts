import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GiaVeComponent } from './gia-ve.component';

describe('GiaVeComponent', () => {
  let component: GiaVeComponent;
  let fixture: ComponentFixture<GiaVeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GiaVeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GiaVeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
