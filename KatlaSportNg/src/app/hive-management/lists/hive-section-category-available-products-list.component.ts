import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HiveSectionService } from '../services/hive-section.service';
import { HiveSectionCategoryAvailableProduct } from '../models/hive-section-category-available-product';

@Component({
  selector: 'app-hive-section-category-available-products-list',
  templateUrl: './hive-section-category-available-products-list.component.html',
  styleUrls: ['./hive-section-category-available-products-list.component.css']
})
export class HiveSectionCategoryAvailableProductsListComponent implements OnInit {

  hiveId: number;
  hiveSectionId: number;
  hiveSectionCategoryId: number;
  defaultProductQuantity: number;
  hiveSectionCategoryAvailableProducts: HiveSectionCategoryAvailableProduct[];

  constructor(
    private route: ActivatedRoute,
    private hiveSectionService: HiveSectionService
  ) { 
    this.defaultProductQuantity = 10;
  }

  ngOnInit() {
    this.route.params.subscribe(p => {
      this.hiveId = p['hiveId'];
      this.hiveSectionId = p['hiveSectionId'];
      this.hiveSectionCategoryId = p['hiveSectionCategoryId'];
      this.hiveSectionService.getHiveSectionAvailableCategoryProducts(this.hiveSectionId, this.hiveSectionCategoryId)
        .subscribe(s => this.hiveSectionCategoryAvailableProducts = s);
    })
  }

  onRequest(product: HiveSectionCategoryAvailableProduct) {
      product.hiveSectionId = this.hiveSectionId;
      if(product.quantity == null || product.quantity <= 0) product.quantity = this.defaultProductQuantity;
      this.hiveSectionService.addHiveSectionCategoryProduct(product).subscribe();
      window.location.reload();
  }
}