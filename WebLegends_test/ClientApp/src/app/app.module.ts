import { BrowserModule } from '@angular/platform-browser';
import {CUSTOM_ELEMENTS_SCHEMA, NgModule} from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import {AppRoutingModule} from "./app-routing.module";
import { FacilityComponent } from './facility/facility.component';
import {StatusService} from "../services/StatusService";
import {FacilityService} from "../services/FacilityService";
import {NgSelectModule} from "@ng-select/ng-select";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {Error404Component} from "../error404/error404.component";
import {LogService} from "../services/LogService";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    FacilityComponent,
    Error404Component
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
