import {Inject, Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import { map } from 'rxjs/operators';
import {FacilityModel} from "../models/facility.model";
import {getAoiUrl} from "../config";
import {LogModel} from "../models/log.model";
import {BaseRestService} from "./base-rest.service";


@Injectable()
export class LogService extends BaseRestService<LogModel>{

  constructor(http: HttpClient) {
    super(http, "api/logs");
  }

  getAllLogPage(pageNumber: number, pageSize: number): Observable<LogModel[]>{
    return this.http.get<LogModel[]>(
      this.url+"/page?pageNumber=" + pageNumber + "&pageSize=" + pageSize).pipe(map(
      (logs: LogModel[]) =>    logs
    ));
  }

  getFacilityLogPage(id: number, pageNumber: number, pageSize: number): Observable<LogModel[]>{
    return this.http.get<LogModel[]>(
      this.url+"/facility/" + id + "/page?pageNumber=" + pageNumber + "&pageSize=" + pageSize).pipe(map(
      (logs: LogModel[]) =>    logs
    ));
  }

  deleteAllLog(facilityId: number) {
    return this.http.delete(this.url + '/facility/' + facilityId);
  }
}
