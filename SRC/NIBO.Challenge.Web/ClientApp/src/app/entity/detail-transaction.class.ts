import { TransactionType } from "../enums/transaction-type.enum";
import { Base } from "./base/base.class";

export class DetailTransaction extends Base
{
    idDetail: Number;
    type: TransactionType;
    date: Date;
    dalue: Number;
    detail: Number;
    idHeader: Number;
}