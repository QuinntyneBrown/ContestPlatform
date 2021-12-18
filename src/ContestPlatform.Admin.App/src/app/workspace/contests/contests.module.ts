import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ContestsRoutingModule } from './contests-routing.module';
import { ContestsComponent } from './contests.component';


@NgModule({
  declarations: [
    ContestsComponent
  ],
  imports: [
    CommonModule,
    ContestsRoutingModule
  ]
})
export class ContestsModule { }
