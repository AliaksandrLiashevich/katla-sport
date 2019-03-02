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
  ) { 
  }

  ngOnInit() {
    this.route.params.subscribe(p => {
      this.hiveId = p['hiveId'];
      this.hiveSectionId = p['hiveSectionId'];
      this.hiveSectionCategoryId = p['hiveSectionCategoryId'];
      this.hiveSectionService.getHiveSectionCategoryProducts(this.hiveSectionId, this.hiveSectionCategoryId)
        .subscribe(s => this.hiveSectionCategoryProducts = s);
    });
  }

  onApproved(hiveSectionCategoryProductId: number) {
    var hiveSectionCategoryProduct = this.hiveSectionCategoryProducts.find(s => s.id == hiveSectionCategoryProductId);    
    this.hiveSectionService.setHiveSectionCategoryProductApprovedStatus(hiveSectionCategoryProductId, true).subscribe(c => hiveSectionCategoryProduct.isApproved = true);
  }

  onDeny(hiveSectionCategoryProductId: number) {
    this.hiveSectionCategoryProducts = this.hiveSectionCategoryProducts.filter(s => s.id != hiveSectionCategoryProductId || s.isDeleted == false);
    this.hiveSectionService.deleteHiveSectionCategoryProduct(hiveSectionCategoryProductId).subscribe();
  }

  onDelete(hiveSectionCategoryProductId: number) {
    var hiveSectionCategoryProduct = this.hiveSectionCategoryProducts.find(s => s.id == hiveSectionCategoryProductId);    
    this.hiveSectionService.setHiveSectionCategoryProductDeletedStatus(hiveSectionCategoryProductId, true).subscribe(c => hiveSectionCategoryProduct.isDeleted = true);
  }

  onRestore(hiveSectionCategoryProductId: number){
    var hiveSectionCategoryProduct = this.hiveSectionCategoryProducts.find(s => s.id == hiveSectionCategoryProductId);
    this.hiveSectionService.setHiveSectionCategoryProductDeletedStatus(hiveSectionCategoryProductId, false).subscribe(c => hiveSectionCategoryProduct.isDeleted = false);
  }

  onPurge(hiveSectionCategoryProductId: number){
    this.hiveSectionCategoryProducts = this.hiveSectionCategoryProducts.filter(s => s.id != hiveSectionCategoryProductId || s.isDeleted == false);
    this.hiveSectionService.deleteHiveSectionCategoryProduct(hiveSectionCategoryProductId).subscribe();
  }
}