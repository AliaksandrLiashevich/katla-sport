import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HiveSection } from '../models/hive-section';
import { HiveService } from '../services/hive.service';
import { HiveSectionService } from '../services/hive-section.service';
import { HiveListItem } from '../models/hive-list-item';

@Component({
  selector: 'app-hive-section-form',
  templateUrl: './hive-section-form.component.html',
  styleUrls: ['./hive-section-form.component.css']
})
export class HiveSectionFormComponent implements OnInit {
  hiveSection: HiveSection;
  hives: HiveListItem[];
  hiveId: number;
  hiveSectionId:number;
  existed = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private hiveService: HiveService,
    private hiveSectionService: HiveSectionService
  ) { }

  ngOnInit() {
    this.hiveService.getHives().subscribe(h => this.hives = h);
    this.route.params.subscribe(p => {
      this.hiveId = p['hiveId'];
      this.hiveSectionId = p['hiveSectionId'];
    });
    this.hiveSectionService.getHiveSection(this.hiveSectionId).subscribe(s => this.hiveSection = s);
  }

  navigateToHivesSections() {
    this.router.navigate([`/hive/${this.hiveId}/sections`]);
  }

  onCancel() {
    this.navigateToHivesSections();
  }

  onSubmit(){
    if(this.existed){
      this.hiveSectionService.updateHiveSection(this.hiveSection).subscribe(e => this.navigateToHivesSections());
    } else {
      this.hiveSectionService.addHiveSection(this.hiveSection).subscribe(e => this.navigateToHivesSections());
    }
  }

  onDelete(){
    this.hiveSectionService.setHiveSectionStatus(this.hiveSection.id, true).subscribe(e => this.hiveSection.isDeleted = true);
  }

  onRestore(){
    this.hiveSectionService.setHiveSectionStatus(this.hiveSection.id, false).subscribe(e => this.hiveSection.isDeleted = false);
  }

  onPurge(){
    this.hiveSectionService.deleteHiveSection(this.hiveSection.id).subscribe(e => this.navigateToHivesSections());
  }
}
