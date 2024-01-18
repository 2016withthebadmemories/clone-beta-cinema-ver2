import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListRapComponent } from './list-rap/list-rap.component';

const routes: Routes = [
  {
    path: '',
    component: ListRapComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class RapRoutingModule {}
