import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatButtonModule}from '@angular/material/button';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import { ListXuatChieuComponent } from './list-xuat-chieu/list-xuat-chieu.component';
import { CreateEditXuatChieuComponent } from './create-edit-xuat-chieu/create-edit-xuat-chieu.component';
import { XuatChieuRoutingModule } from './xuatChieu-routing.module';
import { EditorModule } from '@tinymce/tinymce-angular';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatCheckboxModule } from '@angular/material/checkbox';


@NgModule({
  declarations: [
    ListXuatChieuComponent,
    CreateEditXuatChieuComponent,
  ],
  imports: [
    CommonModule,
    XuatChieuRoutingModule,
    MatDialogModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    EditorModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatCheckboxModule,
    ReactiveFormsModule,
  ],
  providers: []
})
export class XuatChieuModule { }
