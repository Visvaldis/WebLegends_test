import { Component, OnInit } from '@angular/core';
import {LogModel} from "../../models/log.model";
import {FacilityModel} from "../../models/facility.model";
import {ActivatedRoute, Router} from "@angular/router";
import {switchMap} from "rxjs/operators";
import {LogService} from "../../services/log.service";
import {FacilityService} from "../../services/facility.service";
import {StatusModel} from "../../models/status.model";
import {StatusService} from "../../services/status.service";
import {FormBuilder, FormGroup} from "@angular/forms";

@Component({
  selector: 'app-facility-log',
  templateUrl: './facility-log.component.html',
  styleUrls: ['./facility-log.component.css']
})
export class FacilityLogComponent implements OnInit {

  pageNumber = 1;
  pageSize = 10;
  statuses: StatusModel[];
  logs: LogModel[] = [];
  facility: FacilityModel = new FacilityModel();
  constructor(private route: ActivatedRoute, private router: Router,
              private logService: LogService, private facilityService: FacilityService, private statusService: StatusService) { }


  ngOnInit(): void {
    this.route.paramMap.pipe(
      switchMap(params => params.getAll('id'))
    )
      .subscribe(data => {
        this.getFacility(+data)
        this.loadStatuses();
        this.loadLogs(+data);
            });

  }

  private loadStatuses() {
    this.statusService.getAll()
      .subscribe((data: StatusModel[]) => this.statuses = data);
  }

  private loadLogs(id: number) {
    this.logService.getFacilityLogPage(id, this.pageNumber, this.pageSize)
      .subscribe((value: LogModel[]) => {
          this.logs = value;
        },
         error => {
          if (error.status === 404)
          {
            this.router.navigate(['error404']);
          }
          else {
            alert(error.message);
          }
        });
  }

  cancel($event: any) {
    if(this.facility === null){
      this.router.navigate(['']);
    }
    this.getFacility(this.facility.id);
    this.loadLogs(this.facility.id);
  }

  getFacility(id: number){
    this.facilityService.get(id)
      .subscribe((val: FacilityModel) => {
        this.facility = val;},
        error => {
          if (error.status === 404)
          {
            this.router.navigate(['error404']);
          }
          else {
            alert(error.message);
          }});
  }

  deleteLog(p: LogModel) {
    this.logService.delete(p.id)
      .subscribe(() => this.loadLogs(this.facility.id));
  }

  nextpage() {
    this.pageNumber+=1;
    this.loadLogs(this.facility.id);
  }

  previouspage() {
    this.pageNumber-=1;
    this.loadLogs(this.facility.id);
  }

  deleteAllLog(facility: FacilityModel) {
    this.logService.deleteAllLog(facility.id)
      .subscribe(() => this.loadLogs(this.facility.id));
  }

  onDelete($event: any) {
    this.router.navigate(['']);
  }
}
