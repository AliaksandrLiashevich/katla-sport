import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { HiveSectionCategoryProductsListComponent } from './hive-section-category-products-list.component';

describe('HiveListComponent', () => {
  let component: HiveSectionCategoryProductsListComponent;
  let fixture: ComponentFixture<HiveSectionCategoryProductsListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HiveSectionCategoryProductsListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HiveSectionCategoryProductsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});