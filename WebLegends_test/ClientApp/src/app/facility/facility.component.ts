import { Component, OnInit } from '@angular/core';
import {Log} from "../../models/log";
import {Facility} from "../../models/facility";
import {ActivatedRoute, Router} from "@angular/router";
import {switchMap} from "rxjs/operators";
import {LogService} from "../../services/LogService";
import {FacilityService} from "../../services/FacilityService";
import {Status} from "../../models/status";
import {StatusService} from "../../services/StatusService";

@Component({
  selector: 'app-facility',
  templateUrl: './facility.component.html',
  styleUrls: ['./facility.component.css']
})
export class FacilityComponent implements OnInit {

  editMode = false;
  pageNumber = 1;
  pageSize = 10;
  statuses: Status[];
  logs: Log[] = [];
  facility: Facility = new Facility();
  constructor(private route: ActivatedRoute, private router: Router,
              private logService: LogService, private facilityService: FacilityService, private statusService: StatusService) { }


  ngOnInit(): void {
    this.route.paramMap.pipe(
      switchMap(params => params.getAll('id'))
    )
      .subscribe(data => {
        this.facilityService.getFacility(+data)
          .subscribe((val: Facility) => {
              this.facility = val;
              this.loadStatuses();
              this.loadLogs(+data);
            });

      });
  }

  private loadStatuses() {
    this.statusService.getStatuses()
      .subscribe((data: Status[]) => this.statuses = data);
  }

  private loadLogs(id: number) {
    this.logService.getFacilityLogPage(id, this.pageNumber, this.pageSize)
      .subscribe((value: Log[]) => {
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

  save() {
      this.facilityService.updateFacility(this.facility)
        .subscribe(() => this.loadLogs(this.facility.id));
     this.editMode = false;
  }
  editFacility(p: Facility) {
    this.facility = p;
    this.editMode = true;
  }
  cancel() {
    this.facility = new Facility();
    this.editMode = false;
  }

  deleteFacility(p: Facility) {
    this.facilityService.deleteFacility(p.id)
      .subscribe(() =>  this.router.navigate(['']));
  }

  deleteLog(p: Log) {
    this.logService.deleteLog(p.id)
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

  deleteAllLog(facility: Facility) {
    this.logService.deleteAllLog(facility.id)
      .subscribe(() => this.loadLogs(this.facility.id));
  }
}
