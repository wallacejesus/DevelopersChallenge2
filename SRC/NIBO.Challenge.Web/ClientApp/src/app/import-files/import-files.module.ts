import { ImportFilesComponent } from './import-files.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ImportFilesService } from './import-files.service';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [],
  providers: [ImportFilesService]
})
export class ImportFilesModule { }
