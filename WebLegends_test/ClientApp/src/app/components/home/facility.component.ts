import { Component, OnInit } from '@angular/core';
import { FacilityModel } from "../../models/facility.model";
import { StatusService } from "../../services/status.service";
import { StatusModel } from "../../models/status.model";
import { FacilityService } from "../../services/facility.service";
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-facility',
  templateUrl: './facility.component.html',
  styleUrls: ['./facility.component.css']
})
export class FacilityComponent implements OnInit {
  facility: FacilityModel = new FacilityModel();   // изменяемый товар
  facilities: FacilityModel[] = [];                // массив товаров
  statuses: StatusModel[];
  tableMode = true;          // табличный режим
  pageNumber = 1;
  pageSize = 10;
  searchStr: string = null;
  createForm: FormGroup;

  constructor(private facilityService: FacilityService, private statusService: StatusService) { }

  ngOnInit() {
    this.loadFacilities();    // загрузка данных при старте компонента
    this.loadStatuses();
  }
  // получаем данные через сервис
  loadFacilities() {
    this.facilityService.getFacilitiesPage(this.pageNumber, this.pageSize)
      .subscribe((data: FacilityModel[]) => this.facilities = data);
  }
  loadStatuses() {
    this.statusService.getAll()
      .subscribe((data: StatusModel[]) => this.statuses = data);
  }


  cancel($event: any) {
    this.facility = new FacilityModel();
    this.tableMode = true;
    this.loadFacilities();
  }

  add() {
    this.cancel('');
    this.tableMode = false;
  }

  search() {
    this.facilityService.search(this.searchStr)
      .subscribe((data: FacilityModel[]) => {
        this.facilities = data
        console.log(data);
      });
  }

  nextpage() {
    this.pageNumber += 1;
    this.loadFacilities();
  }

  previouspage() {
    this.pageNumber -= 1;
    this.loadFacilities();
  }

  cancelSearch() {
    this.searchStr = null;
    this.loadFacilities();
  }
}
