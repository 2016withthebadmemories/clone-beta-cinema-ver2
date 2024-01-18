import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChonGheComponent } from './chon-ghe.component';

describe('ChonGheComponent', () => {
  let component: ChonGheComponent;
  let fixture: ComponentFixture<ChonGheComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChonGheComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChonGheComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
