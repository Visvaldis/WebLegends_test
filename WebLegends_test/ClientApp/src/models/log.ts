import {Facility} from "./facility";

export class Log {
  public id: number;
  public facility: Facility;
  public fieldName: string;
  public changeDate: Date;
  public oldValue: string;
  public newValue: string;
}
