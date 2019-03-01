import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HiveSectionService } from '../services/hive-section.service';
import { HiveSectionCategory } from '../models/hive-section-categorie';

@Component({
  selector: 'app-hive-section-categories-list',
  templateUrl: './hive-section-categories-list.component.html',
  styleUrls: ['./hive-section-categories-list.component.css']
})
export class HiveSectionCategoriesListComponent implements OnInit {

  hiveId: number;
  hiveSectionId: number;
  hiveSectionCategories: HiveSectionCategory[];

  constructor(
    private route: ActivatedRoute,
    private hiveSectionService: HiveSectionService
  ) { }

  ngOnInit() {
    this.route.params.subscribe(p => {
      this.hiveId = p['hiveId'];
      this.hiveSectionId = p['hiveSectionId'];
      this.hiveSectionService.getHiveSectionCategories(this.hiveSectionId).subscribe(s => this.hiveSectionCategories = s);
    })
  }
}