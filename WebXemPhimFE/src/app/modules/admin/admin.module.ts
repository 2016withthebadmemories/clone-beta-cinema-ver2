import { AuthGuard } from './guards/auth.guard';
import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './modules/login/login.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import { ListCommentComponent } from './modules/comment/list-comment/list-comment.component';
import {MatDialogModule} from '@angular/material/dialog';
import { ListUserComponent } from './modules/user/list-user/list-user.component';
import { CreateEditUserComponent } from './modules/user/create-edit-user/create-edit-user.component';
import { ListPhongComponent } from './modules/phong/list-phong/list-phong.component';
import { CreateEditPhongComponent } from './modules/phong/create-edit-phong/create-edit-phong.component';
import { CreateEditGheComponent } from './modules/ghe/create-edit-ghe/create-edit-ghe.component';
import { ListGheComponent } from './modules/ghe/list-ghe/list-ghe.component';
import { ListXuatChieuComponent } from './modules/xuatChieu/list-xuat-chieu/list-xuat-chieu.component';
import { CreateEditXuatChieuComponent } from './modules/xuatChieu/create-edit-xuat-chieu/create-edit-xuat-chieu.component';
import { ListVeComponent } from './modules/list-ve/list-ve.component';
import { DatVeComponent } from './modules/dat-ve/dat-ve.component';
import { ThongKeComponent } from './modules/thong-ke/thong-ke.component';
 
@NgModule({
  declarations: [AdminComponent],
  imports: [AdminRoutingModule, MatSidenavModule, MatButtonToggleModule],
  exports: [RouterModule],
})
export class AdminModule {}
