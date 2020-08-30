import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {FacilityModel} from "../../../models/facility.model";
import {StatusModel} from "../../../models/status.model";
import {FacilityService} from "../../../services/facility.service";


@Component({
  selector: '[app-facility-row]',
  templateUrl: './facility-row.component.html',
  styleUrls: ['./facility-row.component.css']
})
export class FacilityRowComponent implements OnInit {
  @Input() facility: FacilityModel = new FacilityModel();
  @Output() needReload = new EventEmitter<any>();
  changeMode = false;
  @Output() deleted = new EventEmitter<any>();
  @Input() statuses: StatusModel[];

  constructor(private facilityService: FacilityService) { }

  ngOnInit( ): void {
  }
// сохранение данных
  save() {
    this.facilityService.update(this.facility)
        .subscribe(() => this.reload());
    this.changeMode = false;
  }
  editFacility(p: FacilityModel) {
    this.changeMode = true;
  }

  delete(p: FacilityModel) {
    this.facilityService.delete(p.id)
      .subscribe(() => {
        this.deleted.emit('');
      });
  }
  reload() {
    this.needReload.emit('');
  }


  cancel() {
    this.changeMode = false;

  }
}
