import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateEditPhongComponent } from './create-edit-phong.component';

describe('CreateEditPhongComponent', () => {
  let component: CreateEditPhongComponent;
  let fixture: ComponentFixture<CreateEditPhongComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateEditPhongComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateEditPhongComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
