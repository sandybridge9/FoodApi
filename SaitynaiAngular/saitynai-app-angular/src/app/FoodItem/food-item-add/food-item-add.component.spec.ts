import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FoodItemAddComponent } from './food-item-add.component';

describe('FoodItemAddComponent', () => {
  let component: FoodItemAddComponent;
  let fixture: ComponentFixture<FoodItemAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FoodItemAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FoodItemAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
