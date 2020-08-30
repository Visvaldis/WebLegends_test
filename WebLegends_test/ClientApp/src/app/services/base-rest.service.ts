import {Inject, Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import { map } from 'rxjs/operators';
import {StatusModel} from "../models/status.model";
import {getAoiUrl} from "../config";
import {FacilityModel} from "../models/facility.model";


@Injectable()
export class BaseRestService<T> {

  public get url(): string {
    return getAoiUrl() + this.entityUrl;
  }

  constructor(protected http: HttpClient, private entityUrl: string) {
  }

  getAll(): Observable<T[]>{
    return this.http.get<T[]>(this.url).pipe(map(
      (data: T[]) =>    data
    ));
  }

  get(id: number): Observable<T> {
    return this.http.get<T>(this.url + '/' + id).pipe(map(
      (data: T) =>    data
    ));
  }

  search(name: string): Observable<T[]>{
    const searchUrl = `${this.url}/search/${name}`;
    return this.http.get<T[]>(searchUrl).pipe(map(
      (data: T[]) =>    data
    ));
  }

  create(value: T): Observable<any> {
    return this.http.post(this.url, value);
  }
  update(value: T): Observable<any> {
    return this.http.put(this.url, value);
  }
  delete(id: number): Observable<any> {
    return this.http.delete(this.url + '/' + id);
  }

}
