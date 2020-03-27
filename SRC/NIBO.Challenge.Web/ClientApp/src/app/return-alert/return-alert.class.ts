import { MessageReturn, TypeReturn } from './../helpers/message-return.class';
export class ReturnAlert<TEntity>{

    public show:boolean;
    public title:string;
    public message:string;
    public type:string;
    constructor(returnAPI?:MessageReturn<TEntity>){
        this.message = returnAPI.message;
        this.title = returnAPI.title;
        this.show = true;
        switch(returnAPI.type){
            case TypeReturn.SUCCESS:
                this.type = "alert-success";
                break
            case TypeReturn.WARNING:
                this.type = "alert-warning";
                break;
            case TypeReturn.ERROR:
                this.type = "alert-danger";
                break;
            default:
                break;
            
        }
    }
}