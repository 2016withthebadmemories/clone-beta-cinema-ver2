import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListXuatChieuComponent } from './list-xuat-chieu/list-xuat-chieu.component';

const routes: Routes = [
  {
    path: '',
    component: ListXuatChieuComponent
    ,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class XuatChieuRoutingModule {}
