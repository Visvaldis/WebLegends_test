import {FacilityModel} from "./facility.model";

export class LogModel {
  public id: number;
  public facility: FacilityModel;
  public fieldName: string;
  public changeDate: Date;
  public oldValue: string;
  public newValue: string;
}
