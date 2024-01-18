import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatButtonModule}from '@angular/material/button';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import { ListVeComponent } from './list-ve.component';
import { VeRoutingModule } from './ve-routing.module';
import { ChartsModule } from 'ng2-charts';


@NgModule({
  declarations: [
    ListVeComponent,
  ],
  imports: [
    CommonModule,
    VeRoutingModule,
    MatDialogModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    ChartsModule
  ],
  providers: []
})
export class VeModule { }
