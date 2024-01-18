import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateEditGheComponent } from './create-edit-ghe.component';

describe('CreateEditGheComponent', () => {
  let component: CreateEditGheComponent;
  let fixture: ComponentFixture<CreateEditGheComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateEditGheComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateEditGheComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
