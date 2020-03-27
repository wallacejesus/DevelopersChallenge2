import { ViewDetailService } from './view-detail/view-detail.service';


import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { ImportFilesComponent } from './import-files/import-files.component';
import { ImportFilesModule } from './import-files/import-files.module';
import { ViewDetailComponent } from './view-detail/view-detail.component';
import { ViewDetailModule } from './view-detail/view-detail.module';
import { ReturnAlertComponent } from './return-alert/return-alert.component';
import { ReturnAlert } from './return-alert/return-alert.class';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    ImportFilesComponent,
    ViewDetailComponent,
    ReturnAlertComponent    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: ImportFilesComponent, pathMatch: 'full' },
      { path: 'view-detail', component: ViewDetailComponent }
    ]),
    ImportFilesModule
  ],
  providers: [
    ViewDetailService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
