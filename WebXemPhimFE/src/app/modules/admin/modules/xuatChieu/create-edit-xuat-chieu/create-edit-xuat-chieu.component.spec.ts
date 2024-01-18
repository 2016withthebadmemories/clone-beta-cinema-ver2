import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateEditXuatChieuComponent } from './create-edit-xuat-chieu.component';

describe('CreateEditXuatChieuComponent', () => {
  let component: CreateEditXuatChieuComponent;
  let fixture: ComponentFixture<CreateEditXuatChieuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateEditXuatChieuComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateEditXuatChieuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
