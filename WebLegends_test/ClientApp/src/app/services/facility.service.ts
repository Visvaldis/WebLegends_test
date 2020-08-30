import {Inject, Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import { map } from 'rxjs/operators';
import {Facility} from "../models/facility";
import {getAoiUrl} from "../config";
import {BaseRestService} from "./base-rest.service";


@Injectable()
export class FacilityService extends BaseRestService<Facility>{


constructor(http: HttpClient) {
    super(http, "api/facilities");
  }

  getFacilitiesPage(pageNumber: number, pageSize: number): Observable<Facility[]>{
    return this.http.get<Facility[]>(
      this.url+"/page?pageNumber=" + pageNumber + "&pageSize=" + pageSize).pipe(map(
      (facilities: Facility[]) =>    facilities
    ));
  }


  getFacilityByStatus(name: string): Observable<Facility[]>{
    const searchUrl = `${this.url}/status/${name}`;
    return this.http.get<Facility[]>(searchUrl).pipe(map(
      (facilities: Facility[]) =>    facilities ));
  }

}
