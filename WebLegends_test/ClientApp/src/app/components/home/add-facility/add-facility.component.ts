import { Component, Input, OnInit, Output } from '@angular/core';
import { FacilityModel } from "../../../models/facility.model";
import { StatusModel } from "../../../models/status.model";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { FacilityService } from "../../../services/facility.service";
import { StatusService } from "../../../services/status.service";
import { EventEmitter } from '@angular/core';

@Component({
  selector: 'app-add-facility',
  templateUrl: './add-facility.component.html',
  styleUrls: ['./add-facility.component.css']
})
export class AddFacilityComponent implements OnInit {

  facility: FacilityModel = new FacilityModel();   // изменяемый товар
  statuses: StatusModel[];

  createForm: FormGroup;

  @Output() canceled = new EventEmitter<any>();

  constructor(private facilityService: FacilityService, private statusService: StatusService, private fb: FormBuilder) { }

  ngOnInit() {
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
  private loadStatuses() {
    this.statusService.getAll()
      .subscribe((data: StatusModel[]) => this.statuses = data);
  }

  save() {
    this.facility.name = this.createForm.controls['name'].value;
    this.facility.phone_Number = this.createForm.controls['phone'].value;
    this.facility.email = this.createForm.controls['email'].value;
    this.facility.address = this.createForm.controls['address'].value;
    this.facility.status = this.createForm.controls['status'].value;

    this.facilityService.create(this.facility)
      .subscribe((data: FacilityModel) => {
        this.cancel()
      },
        error => {
          alert(error.message);
        }
      );
  }

  cancel() {
    this.canceled.emit('');
  }
}
