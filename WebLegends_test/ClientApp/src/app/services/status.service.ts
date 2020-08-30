import {Inject, Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import { map } from 'rxjs/operators';
import {StatusModel} from "../models/status.model";
import {getAoiUrl} from "../config";
import {BaseRestService} from "./base-rest.service";


@Injectable()
export class StatusService extends BaseRestService<StatusModel>{

  constructor(http: HttpClient) {
    super(http, "api/statuses");
  }



}
