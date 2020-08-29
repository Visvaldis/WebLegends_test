import {Inject, Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import { map } from 'rxjs/operators';
import {Facility} from "../models/facility";
import {getAoiUrl} from "../config";
import {Log} from "../models/log";


@Injectable()
export class LogService {

  private url = getAoiUrl() + "api/logs";

  constructor(private http: HttpClient) {
  }

  getAllLogPage(pageNumber: number, pageSize: number): Observable<Log[]>{
    return this.http.get<Log[]>(
      this.url+"/page?pageNumber=" + pageNumber + "&pageSize=" + pageSize).pipe(map(
      (logs: Log[]) =>    logs
    ));
  }

  getFacilityLogPage(id: number, pageNumber: number, pageSize: number): Observable<Log[]>{
    return this.http.get<Log[]>(
      this.url+"/facility/" + id + "/page?pageNumber=" + pageNumber + "&pageSize=" + pageSize).pipe(map(
      (logs: Log[]) =>    logs
    ));
  }



  deleteLog(id: number) {
    return this.http.delete(this.url + '/' + id);
  }
  deleteAllLog(facilityId: number) {
    return this.http.delete(this.url + '/facility/' + facilityId);
  }
}
