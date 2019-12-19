import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FoodCategoryUpdateComponent } from './food-category-update.component';

describe('FoodCategoryUpdateComponent', () => {
  let component: FoodCategoryUpdateComponent;
  let fixture: ComponentFixture<FoodCategoryUpdateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FoodCategoryUpdateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FoodCategoryUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
