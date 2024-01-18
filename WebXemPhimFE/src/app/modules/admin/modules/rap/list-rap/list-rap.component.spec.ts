import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListRapComponent } from './list-rap.component';

describe('ListRapComponent', () => {
  let component: ListRapComponent;
  let fixture: ComponentFixture<ListRapComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListRapComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListRapComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
