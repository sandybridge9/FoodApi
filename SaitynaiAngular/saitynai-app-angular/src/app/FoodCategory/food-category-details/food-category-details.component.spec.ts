import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FoodCategoryDetailsComponent } from './food-category-details.component';

describe('FoodCategoryDetailsComponent', () => {
  let component: FoodCategoryDetailsComponent;
  let fixture: ComponentFixture<FoodCategoryDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FoodCategoryDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FoodCategoryDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
