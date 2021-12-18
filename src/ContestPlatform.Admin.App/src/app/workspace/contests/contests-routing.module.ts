import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContestsComponent } from './contests.component';

const routes: Routes = [{ path: '', component: ContestsComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ContestsRoutingModule { }
