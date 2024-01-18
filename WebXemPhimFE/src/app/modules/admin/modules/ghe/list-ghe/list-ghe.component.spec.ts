import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListGheComponent } from './list-ghe.component';

describe('ListGheComponent', () => {
  let component: ListGheComponent;
  let fixture: ComponentFixture<ListGheComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListGheComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListGheComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
