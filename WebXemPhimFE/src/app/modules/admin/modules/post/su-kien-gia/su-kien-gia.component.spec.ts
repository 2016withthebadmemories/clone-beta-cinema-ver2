import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SuKienGiaComponent } from './su-kien-gia.component';

describe('SuKienGiaComponent', () => {
  let component: SuKienGiaComponent;
  let fixture: ComponentFixture<SuKienGiaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SuKienGiaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SuKienGiaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
