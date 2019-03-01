import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { HiveSectionCategoryAvailableProductsListComponent } from './hive-section-category-available-products-list.component';

describe('HiveListComponent', () => {
  let component: HiveSectionCategoryAvailableProductsListComponent;
  let fixture: ComponentFixture<HiveSectionCategoryAvailableProductsListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HiveSectionCategoryAvailableProductsListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HiveSectionCategoryAvailableProductsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});