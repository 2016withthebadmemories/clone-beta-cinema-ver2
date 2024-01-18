import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatButtonModule}from '@angular/material/button';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import { ListUserComponent } from './list-user/list-user.component';
import { CreateEditUserComponent } from './create-edit-user/create-edit-user.component';
import { UserRoutingModule } from './user-routing.module';


@NgModule({
  declarations: [
    ListUserComponent,
    CreateEditUserComponent
  ],
  imports: [
    CommonModule,
    UserRoutingModule,
    MatDialogModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule
  ],
  providers: []
})
export class UserModule { }
