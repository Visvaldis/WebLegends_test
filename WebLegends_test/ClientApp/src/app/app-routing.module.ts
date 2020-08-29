import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {HomeComponent} from "./home/home.component";
import {FacilityComponent} from "./facility/facility.component";
import {Error404Component} from "../error404/error404.component";




// определение маршрутов
const routes: Routes = [
  { path: '', component: HomeComponent},
  { path: 'facility/:id', component: FacilityComponent},
  { path: 'error404', component: Error404Component},
  { path: '*', redirectTo: ''}
];

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
