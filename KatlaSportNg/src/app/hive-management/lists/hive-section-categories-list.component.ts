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

  hiveSectionId: number;
  hiveSectionCategories: HiveSectionCategory[];

  constructor(
    private route: ActivatedRoute,
    private hiveSectionService: HiveSectionService
  ) { }

  ngOnInit() {
    this.route.params.subscribe(p => {
      this.hiveSectionId = p['id'];
      this.hiveSectionService.getHiveSectionCategories(this.hiveSectionId).subscribe(s => this.hiveSectionCategories = s);
    })
  }
}