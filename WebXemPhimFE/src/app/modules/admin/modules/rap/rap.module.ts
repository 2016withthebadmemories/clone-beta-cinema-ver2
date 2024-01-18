import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatButtonModule}from '@angular/material/button';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import { ListRapComponent } from './list-rap/list-rap.component';
import { CreateEditRapComponent } from './create-edit-rap/create-edit-rap.component';
import { RapRoutingModule } from './rap-routing.module';


@NgModule({
  declarations: [
    ListRapComponent,
    CreateEditRapComponent,
  ],
  imports: [
    CommonModule,
    RapRoutingModule,
    MatDialogModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule
  ],
  providers: []
})
export class RapModule { }
