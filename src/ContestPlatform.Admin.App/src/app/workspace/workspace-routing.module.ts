import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WorkspaceComponent } from './workspace.component';

const routes: Routes = [{ path: '', component: WorkspaceComponent }, { path: 'contests', loadChildren: () => import('./contests/contests.module').then(m => m.ContestsModule) }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WorkspaceRoutingModule { }
