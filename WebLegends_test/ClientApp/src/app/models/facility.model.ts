import {StatusModel} from "./status.model";

export class FacilityModel {
  public id: number;
  public name: string;
  public email: string;
  public phone_Number: string;
  public status: StatusModel;
  public address: string;
}
