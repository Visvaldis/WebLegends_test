import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FacilityComponent } from "./components/home/facility.component";
import { FacilityLogComponent } from "./components/facility-log/facility-log.component";
import { Error404Component } from "./components/error404/error404.component";




// определение маршрутов
const routes: Routes = [
  { path: '', component: FacilityComponent },
  { path: 'facility/:id', component: FacilityLogComponent },
  { path: 'error404', component: Error404Component },
  { path: '*', redirectTo: '' }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
