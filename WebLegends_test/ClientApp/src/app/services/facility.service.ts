import {Inject, Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import { map } from 'rxjs/operators';
import {FacilityModel} from "../models/facility.model";
import {getAoiUrl} from "../config";
import {BaseRestService} from "./base-rest.service";


@Injectable()
export class FacilityService extends BaseRestService<FacilityModel>{


constructor(http: HttpClient) {
    super(http, "api/facilities");
  }

  getFacilitiesPage(pageNumber: number, pageSize: number): Observable<FacilityModel[]>{
    return this.http.get<FacilityModel[]>(
      this.url+"/page?pageNumber=" + pageNumber + "&pageSize=" + pageSize).pipe(map(
      (facilities: FacilityModel[]) =>    facilities
    ));
  }


  getFacilityByStatus(name: string): Observable<FacilityModel[]>{
    const searchUrl = `${this.url}/status/${name}`;
    return this.http.get<FacilityModel[]>(searchUrl).pipe(map(
      (facilities: FacilityModel[]) =>    facilities ));
  }

}
