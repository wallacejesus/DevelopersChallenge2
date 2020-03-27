import { MessageReturn } from './../helpers/message-return.class';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpRequest, HttpEventType } from '@angular/common/http';

@Injectable()
export class ImportFilesService {

  constructor(private http:HttpClient) { }

  uploadOFX(files:Array<File>,callback?:(messageReturn?:any)=>void):void{
    if (files.length === 0)
      return;

    let formData = new FormData();

    for (var i = 0; i < files.length; i++) {
      formData.append(files[i].name, files[i]);
    }  
    let httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
    
    this.http.post('/api/Upload', formData)
    .toPromise()
    .then(callback)
  }

}
