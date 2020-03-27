import { ReturnAlert } from './return-alert.class';
import { Component, OnInit,Input } from '@angular/core';

@Component({
  selector: 'app-return-alert',
  templateUrl: './return-alert.component.html',
  styleUrls: ['./return-alert.component.css']
})
export class ReturnAlertComponent implements OnInit {
  @Input() alert:ReturnAlert<any>;
  constructor() { }
  
  ngOnInit() {
  }

}
