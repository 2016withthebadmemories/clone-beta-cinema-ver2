import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatButtonModule}from '@angular/material/button';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import { PhongRoutingModule } from './phong-routing.module';
import { CreateEditPhongComponent } from './create-edit-phong/create-edit-phong.component';
import { ListPhongComponent } from './list-phong/list-phong.component';
import { EditorModule } from '@tinymce/tinymce-angular';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatCheckboxModule } from '@angular/material/checkbox';


@NgModule({
  declarations: [
    ListPhongComponent,
    CreateEditPhongComponent,
  ],
  imports: [
    CommonModule,
    PhongRoutingModule,
    MatDialogModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    EditorModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatCheckboxModule,
    ReactiveFormsModule,
  ],
  providers: []
})
export class PhongModule { }
