import {Inject, Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import { map } from 'rxjs/operators';
import {Facility} from "../models/facility";
import {getBaseUrl} from "../config";


@Injectable()
export class FacilityService {

  private url = getBaseUrl() + "api/facilities";

  constructor(private http: HttpClient) {
  }

  getFacilitiesPage(pageNumber: number, pageSize: number): Observable<Facility[]>{
    return this.http.get<Facility[]>(
      this.url+"/page?pageNumber=" + pageNumber + "&pageSize=" + pageSize).pipe(map(
      (facilities: Facility[]) =>    facilities
    ));
  }

  searchFacilities(name: string): Observable<Facility[]>{
    const searchUrl = `${this.url}/search/${name}`;
    return this.http.get<Facility[]>(searchUrl).pipe(map(
      (facilities: Facility[]) =>    facilities
    ));
  }

  getFacilityByStatus(name: string): Observable<Facility[]>{
    const searchUrl = `${this.url}/status/${name}`;
    return this.http.get<Facility[]>(searchUrl).pipe(map(
      (facilities: Facility[]) =>    facilities ));
  }

  getFacility(id: number): Observable<Facility> {
    return this.http.get<Facility>(this.url + '/' + id).pipe(map(
      (facility: Facility) =>    facility
    ));
  }

  createFacility(facility: Facility) {
    return this.http.post(this.url, facility);
  }
  updateFacility(facility: Facility) {
    return this.http.put(this.url + '/' + facility.id, facility);
  }
  deleteFacility(id: number) {
    return this.http.delete(this.url + '/' + id);
  }

}
