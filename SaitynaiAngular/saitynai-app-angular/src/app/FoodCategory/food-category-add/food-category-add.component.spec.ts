import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FoodCategoryAddComponent } from './food-category-add.component';

describe('FoodCategoryAddComponent', () => {
  let component: FoodCategoryAddComponent;
  let fixture: ComponentFixture<FoodCategoryAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FoodCategoryAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FoodCategoryAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
