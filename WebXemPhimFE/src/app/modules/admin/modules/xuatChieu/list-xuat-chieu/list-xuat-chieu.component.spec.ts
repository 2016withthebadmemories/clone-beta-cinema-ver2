import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListXuatChieuComponent } from './list-xuat-chieu.component';

describe('ListXuatChieuComponent', () => {
  let component: ListXuatChieuComponent;
  let fixture: ComponentFixture<ListXuatChieuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListXuatChieuComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListXuatChieuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
