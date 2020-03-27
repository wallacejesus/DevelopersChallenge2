import { ReturnAlertComponent } from './../return-alert/return-alert.component';
import { ReturnAlert } from './../return-alert/return-alert.class';
import { MessageReturn } from './../helpers/message-return.class';
import { ImportFilesService } from './import-files.service';
import { Component, OnInit ,ViewChild} from '@angular/core';
import { Form } from '@angular/forms';
import { HeaderTransaction } from '../entity/header-transaction.class';


@Component({
  selector: 'app-import-files',
  templateUrl: './import-files.component.html',
  styleUrls: ['./import-files.component.css']
})
export class ImportFilesComponent implements OnInit {
  public files: Array<File>;
  public returnAlert:ReturnAlert<HeaderTransaction>;
  public numero:number;
  //@ViewChild(ReturnAlertComponent,null) returnAlertComponent:ReturnAlertComponent;
  constructor(public importFileService:ImportFilesService) { }
  onUpload(){
    this.importFileService.uploadOFX(this.files,(messageReturn:MessageReturn<HeaderTransaction>)=>{
      console.log(messageReturn)
      this.returnAlert = new ReturnAlert(messageReturn);
      console.log(this.returnAlert);
    });
  }

  Callback(messageReturn:MessageReturn<HeaderTransaction>){
    this.numero = 0;
     //this.returnAlert = new ReturnAlert(true,null,messageReturn.Message);
  }
  getInformationFile(file:any){
    this.files = file.target.files;
    console.log(this.returnAlert);
  }
  ngOnInit() {
  }

}
