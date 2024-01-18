import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListGheComponent } from './list-ghe/list-ghe.component';

const routes: Routes = [
  {
    path: '',
    component: ListGheComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class GheRoutingModule {}
