import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatButtonModule}from '@angular/material/button';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import { ListPostComponent } from './list-post/list-post.component';
import { PostRoutingModule } from './post-routing.module';
import { EditorModule } from '@tinymce/tinymce-angular';
import { CreateEditPostComponent } from './create-edit-post/create-edit-post.component';
import { MatSelectModule } from '@angular/material/select';
import {Component} from '@angular/core';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatNativeDateModule} from '@angular/material/core';
import {MatCheckboxModule} from '@angular/material/checkbox';
import { SuKienGiaComponent } from './su-kien-gia/su-kien-gia.component';

@NgModule({
  declarations: [
    ListPostComponent,
    CreateEditPostComponent,
    SuKienGiaComponent,
  ],
  imports: [
    CommonModule,
    PostRoutingModule,
    MatDialogModule,
    EditorModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatCheckboxModule,
    ReactiveFormsModule,
    CommonModule
  ],
  providers: []
})
export class PostModule { }
