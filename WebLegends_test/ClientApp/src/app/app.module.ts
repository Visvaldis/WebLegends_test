import { BrowserModule } from '@angular/platform-browser';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { FacilityComponent } from './components/home/facility.component';
import { AppRoutingModule } from "./app-routing.module";
import { FacilityLogComponent } from './components/facility-log/facility-log.component';
import { StatusService } from "./services/status.service";
import { FacilityService } from "./services/facility.service";
import { NgSelectModule } from "@ng-select/ng-select";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { Error404Component } from "./components/error404/error404.component";
import { LogService } from "./services/log.service";
import { AddFacilityComponent } from './components/home/add-facility/add-facility.component';
import { FacilityRowComponent } from './components/home/facility-row/facility-row.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    FacilityComponent,
    FacilityLogComponent,
    Error404Component,
    AddFacilityComponent,
    FacilityRowComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    NgSelectModule,
    AppRoutingModule,
    BrowserAnimationsModule,
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  providers: [StatusService, FacilityService, LogService],
  bootstrap: [AppComponent]
})
export class AppModule { }
