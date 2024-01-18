import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListVeComponent } from './list-ve.component';

const routes: Routes = [
  {
    path: '',
    component: ListVeComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class VeRoutingModule {}
