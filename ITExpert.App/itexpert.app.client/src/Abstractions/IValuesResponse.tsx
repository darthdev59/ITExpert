import { IError } from "./IError";
import { IValues } from "./IValues";

export interface IValuesResponse {
    data: IValues[];
    isSuccess: boolean;
    isFailure: boolean;
    error: IError;
}

