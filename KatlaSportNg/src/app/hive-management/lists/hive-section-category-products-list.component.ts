import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HiveSectionService } from '../services/hive-section.service';
import { HiveSectionCategoryProduct } from '../models/hive-section-category-product';

@Component({
  selector: 'app-hive-section-category-products-list',
  templateUrl: './hive-section-category-products-list.component.html',
  styleUrls: ['./hive-section-category-products-list.component.css']
})
export class HiveSectionCategoryProductsListComponent implements OnInit {

  hiveId: number;
  hiveSectionId: number;
  hiveSectionCategoryId: number;
  hiveSectionCategoryProducts: HiveSectionCategoryProduct[];

  constructor(
    private route: ActivatedRoute,
    private hiveSectionService: HiveSectionService
  ) { }

  ngOnInit() {
    this.route.params.subscribe(p => {
      this.hiveId = p['hiveId'];
      this.hiveSectionId = p['hiveSectionId'];
      this.hiveSectionCategoryId = p['hiveSectionCategoryId'];
      this.hiveSectionService.getHiveSectionCategoryProducts(this.hiveSectionId, this.hiveSectionCategoryId)
        .subscribe(s => this.hiveSectionCategoryProducts = s);
    })
  }
}