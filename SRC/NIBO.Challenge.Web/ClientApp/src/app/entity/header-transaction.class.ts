import { DetailTransaction } from "./detail-transaction.class";
import { Base } from "./base/base.class";

export class HeaderTransaction extends Base
{
    IdHeader: number;
    DateStart: Date | string;
    DateEnd: Date | string;

    public listDetailsTransaction: Array<DetailTransaction>;

}