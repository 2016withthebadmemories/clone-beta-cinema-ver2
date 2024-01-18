import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatButtonModule}from '@angular/material/button';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import { ThongKeComponent } from './thong-ke.component';
import { ThongKeRoutingModule } from './thong-ke-routing.module';
import { ChartsModule } from 'ng2-charts';


@NgModule({
  declarations: [
    ThongKeComponent,
  ],
  imports: [
    CommonModule,
    ThongKeRoutingModule,
    MatDialogModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    ChartsModule
  ],
  providers: []
})
export class ThongKeModule { }
