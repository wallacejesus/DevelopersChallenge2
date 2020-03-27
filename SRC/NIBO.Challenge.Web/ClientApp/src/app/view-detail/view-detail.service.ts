import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';

@Injectable()
export class ViewDetailService {
  public httpOptions:any = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }
  constructor(private http:HttpClient) { }
  getTransactions(callback?:(messageReturn?:any)=>void){

    this.http.get('/api/DetailTransaction')
    .toPromise()
    .then(callback);

  }

  getExcellFileToDownload(callback?:(messageReturn?:any)=>void){
    this.http.post('/api/DetailTransaction',{},this.httpOptions)
    .toPromise()
    .then(callback);
  }

}
