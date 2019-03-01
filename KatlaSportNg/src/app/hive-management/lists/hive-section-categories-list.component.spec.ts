import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { HiveSectionCategoriesListComponent } from './hive-section-categories-list.component';

describe('HiveListComponent', () => {
  let component: HiveSectionCategoriesListComponent;
  let fixture: ComponentFixture<HiveSectionCategoriesListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HiveSectionCategoriesListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HiveSectionCategoriesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});