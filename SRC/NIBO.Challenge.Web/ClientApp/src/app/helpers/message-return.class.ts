export class MessageReturn<TEntity>
{
    type: TypeReturn;
    message: string;
    data:TEntity;
    title:string;
    constructor(typeReturn: TypeReturn, message: string,data?:TEntity,title?:string){
        this.type = typeReturn;
        this.message = message;
        this.data = data;
        this.title = title;
    };
}
export enum TypeReturn {
    SUCCESS = 1,
    WARNING = 2,
      ERROR = 3
}