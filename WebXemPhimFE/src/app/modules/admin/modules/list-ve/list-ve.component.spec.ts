import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListVeComponent } from './list-ve.component';

describe('ListVeComponent', () => {
  let component: ListVeComponent;
  let fixture: ComponentFixture<ListVeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListVeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListVeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
