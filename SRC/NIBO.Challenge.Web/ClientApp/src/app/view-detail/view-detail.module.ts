import { ViewDetailService } from './view-detail.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ViewDetailComponent } from './view-detail.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [ViewDetailComponent],
  providers:[ViewDetailService]
})
export class ViewDetailModule { }
