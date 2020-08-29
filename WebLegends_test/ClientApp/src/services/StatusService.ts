import {Inject, Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import { map } from 'rxjs/operators';
import {Facility} from "../models/facility";

import {Status} from "../models/status";
import {getBaseUrl} from "../config";


@Injectable()
export class StatusService {

  private url = getBaseUrl() + "/api/statuses";

  constructor(private http: HttpClient) {
  }

  getStatuses(): Observable<Status[]>{
    return this.http.get<Status[]>(this.url).pipe(map(
      (statuses: Status[]) =>    statuses
    ));
  }

  searchStatuses(name: string): Observable<Status[]>{
    const searchUrl = `${this.url}/search/${name}`;
    return this.http.get<Status[]>(searchUrl).pipe(map(
      (statuses: Status[]) =>    statuses
    ));
  }

  getStatus(id: number): Observable<Status> {
    return this.http.get<Status>(this.url + '/' + id).pipe(map(
      (status: Status) =>    status
    ));
  }

  createStatus(status: Status) {
    return this.http.post(this.url, status);
  }
  updateStatus(status: Status) {
    return this.http.put(this.url + '/' + status.id, status);
  }
  deleteStatus(id: number) {
    return this.http.delete(this.url + '/' + id);
  }

}
