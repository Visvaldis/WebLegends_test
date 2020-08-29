import {Component, OnInit} from '@angular/core';
import {Facility} from "../../models/facility";
import {StatusService} from "../../services/StatusService";
import {Status} from "../../models/status";
import {FacilityService} from "../../services/FacilityService";
import {NgModule, ViewChild} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {FormControl, FormGroup, ReactiveFormsModule, FormsModule} from '@angular/forms';
import {NgSelectModule, NgOption} from '@ng-select/ng-select';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  facility: Facility = new Facility();   // изменяемый товар
  facilities: Facility[];                // массив товаров
  statuses: Status[];
  tableMode = true;          // табличный режим
  pageNumber = 1;
  pageSize = 10;

  constructor(private facilityService: FacilityService, private statusService: StatusService) { }

  ngOnInit() {
    this.loadFacilities();    // загрузка данных при старте компонента
    this.loadStatuses();
    console.log(this.facilities)

  }
  // получаем данные через сервис
  loadFacilities() {
    this.facilityService.getFacilitiesPage(this.pageNumber, this.pageSize)
      .subscribe((data: Facility[]) => this.facilities = data);
  }
  private loadStatuses() {
    this.statusService.getStatuses()
      .subscribe((data: Status[]) => this.statuses = data);
  }
  // сохранение данных
  save() {
    if (this.facility.id == null) {
      this.facilityService.createFacility(this.facility)
        .subscribe((data: Facility) => this.facilities.push(data));
    } else {
      this.facilityService.updateFacility(this.facility)
        .subscribe(() => this.loadFacilities());
    }
    this.cancel();
  }
  editFacility(p: Facility) {
    this.facility = p;
  }
  cancel() {
    this.facility = new Facility();
    this.tableMode = true;
  }
  delete(p: Facility) {
    this.facilityService.deleteFacility(p.id)
      .subscribe(() => this.loadFacilities());
  }
  add() {
    this.cancel();
    this.tableMode = false;
  }


  nextpage() {
    this.pageNumber+=1;
    this.loadFacilities();
  }

  previouspage() {
    this.pageNumber-=1;
    this.loadFacilities();
  }
}
