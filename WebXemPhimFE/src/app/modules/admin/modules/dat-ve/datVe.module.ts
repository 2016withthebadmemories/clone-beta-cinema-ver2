import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatButtonModule}from '@angular/material/button';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import { DatVeComponent } from './dat-ve.component';
import { DatVeRoutingModule } from './datVe-routing.module';


@NgModule({
  declarations: [
    DatVeComponent,
  ],
  imports: [
    CommonModule,
    DatVeRoutingModule,
    MatDialogModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule
  ],
  providers: []
})
export class DatVeModule { }
