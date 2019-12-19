import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FoodItemUpdateComponent } from './food-item-update.component';

describe('FoodItemUpdateComponent', () => {
  let component: FoodItemUpdateComponent;
  let fixture: ComponentFixture<FoodItemUpdateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FoodItemUpdateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FoodItemUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
