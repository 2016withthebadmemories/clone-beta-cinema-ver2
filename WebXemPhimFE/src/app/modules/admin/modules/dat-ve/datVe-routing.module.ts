import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DatVeComponent } from './dat-ve.component';

const routes: Routes = [
  {
    path: '',
    component: DatVeComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DatVeRoutingModule {}
