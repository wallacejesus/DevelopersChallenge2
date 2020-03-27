import { ReturnAlert } from './../return-alert/return-alert.class';
import { ViewDetailService } from './view-detail.service';
import { Component, OnInit} from '@angular/core';
import { MessageReturn,TypeReturn } from '../helpers/message-return.class';
import { DetailTransaction } from '../entity/detail-transaction.class';


@Component({
  selector: 'app-view-detail',
  templateUrl: './view-detail.component.html',
  styleUrls: ['./view-detail.component.css']
})
export class ViewDetailComponent implements OnInit {
  public returnAlert:ReturnAlert<Array<DetailTransaction>>;
  public listDetailsTransaction:Array<DetailTransaction>;
  constructor(private viewDetailService:ViewDetailService) { 
  }
  exportToExcell(){
    this.viewDetailService.getExcellFileToDownload((messageReturn:MessageReturn<string>)=>{
      console.log(messageReturn)
      if(messageReturn.type!=TypeReturn.SUCCESS){
          this.returnAlert = new ReturnAlert<string>(messageReturn);
      }
      window.open(messageReturn.data,'_blank');
    })
  }
  ngOnInit() {
    this.viewDetailService.getTransactions((messageReturn:MessageReturn<Array<DetailTransaction>>)=>{
      console.log(messageReturn)
      if(messageReturn.type!=TypeReturn.SUCCESS){
          this.returnAlert = new ReturnAlert<Array<DetailTransaction>>(messageReturn);
      }
      this.listDetailsTransaction = messageReturn.data;    
    });  
  }
}
