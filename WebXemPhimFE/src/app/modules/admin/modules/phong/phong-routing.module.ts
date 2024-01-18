import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListPhongComponent } from './list-phong/list-phong.component';

const routes: Routes = [
  {
    path: '',
    component: ListPhongComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PhongRoutingModule {}
