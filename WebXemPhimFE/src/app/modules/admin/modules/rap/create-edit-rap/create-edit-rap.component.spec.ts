import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateEditRapComponent } from './create-edit-rap.component';

describe('CreateEditRapComponent', () => {
  let component: CreateEditRapComponent;
  let fixture: ComponentFixture<CreateEditRapComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateEditRapComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateEditRapComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
