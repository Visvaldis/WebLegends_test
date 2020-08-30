import {Component, OnInit} from '@angular/core';
import {Facility} from "../../models/facility";
import {StatusService} from "../../services/StatusService";
import {Status} from "../../models/status";
import {FacilityService} from "../../services/FacilityService";
import {NgModule, ViewChild} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {FormControl, FormGroup, ReactiveFormsModule, FormsModule, FormBuilder, Validators} from '@angular/forms';
import {NgSelectModule, NgOption} from '@ng-select/ng-select';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  facility: Facility = new Facility();   // изменяемый товар
  facilities: Facility[] = [];                // массив товаров
  statuses: Status[];
  tableMode = true;          // табличный режим
  pageNumber = 1;
  pageSize = 10;
  searchStr: string = null;
  createForm: FormGroup;

  constructor(private facilityService: FacilityService, private statusService: StatusService,  private fb: FormBuilder) { }

  ngOnInit() {
    this.loadFacilities();    // загрузка данных при старте компонента
    this.loadStatuses();

    this.createForm = this.fb.group(
      {
        name: ['', [Validators.required]],
        email: ['', [Validators.required, Validators.email]],
        phone: ['', [Validators.required, Validators.minLength(10)]],
        address: ['', [Validators.required]],
        status: ['', [Validators.required]]
      }
    );

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
      this.facility.name = this.createForm.controls['name'].value;
      this.facility.phone_Number = this.createForm.controls['phone'].value;
      this.facility.email = this.createForm.controls['email'].value;
      this.facility.address = this.createForm.controls['address'].value;
      this.facility.status = this.createForm.controls['status'].value;

      this.facilityService.createFacility(this.facility)
        .subscribe((data: Facility) =>
          {
             this.facilities.push(data)
          },
          error => {
              alert(error.message);
          }
        );
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

  search(){
    this.facilityService.searchFacilities(this.searchStr)
      .subscribe((data: Facility[]) => {
        this.facilities = data
        console.log(data);
      });
  }

  nextpage() {
    this.pageNumber+=1;
    this.loadFacilities();
  }

  previouspage() {
    this.pageNumber-=1;
    this.loadFacilities();
  }

  cancelSearch() {
    this.searchStr = null;
    this.loadFacilities();
  }
}
