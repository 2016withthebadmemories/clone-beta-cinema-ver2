import { PostModule } from './../home/modules/post/post.module';
import { ListPostComponent } from './modules/post/list-post/list-post.component';
import { AuthGuard } from './guards/auth.guard';
import { AdminComponent } from './admin.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: "",
    component: AdminComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: "topic",
        loadChildren: () => import("./modules/topic/topic.module").then(m => m.TopicModule)
      },
      {
        path: "comment",
        loadChildren: () => import("./modules/comment/comment.module").then(m => m.CommentModule)
      },
      {
        path: "post",
        loadChildren: () => import("./modules/post/post.module").then(m => m.PostModule)
      },
      {
        path: "user",
        loadChildren: () => import("./modules/user/user.module").then(m => m.UserModule)
      },
      {
        path: "rap",
        loadChildren: () => import("./modules/rap/rap.module").then(m => m.RapModule)
      },
      {
        path: "ghe",
        loadChildren: () => import("./modules/ghe/ghe.module").then(m => m.GheModule)
      },
      {
        path: "phong",
        loadChildren: () => import("./modules/phong/phong.module").then(m => m.PhongModule)
      },
      {
        path: "xuatChieu",
        loadChildren: () => import("./modules/xuatChieu/xuatChieu.module").then(m => m.XuatChieuModule)
      },
      {
        path: "ve",
        loadChildren: () => import("./modules/list-ve/ve.module").then(m => m.VeModule)
      },
      {
        path: "dat-ve",
        loadChildren: () => import("./modules/dat-ve/datVe.module").then(m => m.DatVeModule)
      },
      {
        path: "thong-ke",
        loadChildren: () => import("./modules/thong-ke/thong-ke.module").then(m => m.ThongKeModule)
      },
      {
        path: "xac-nhan",
        loadChildren: () => import("./modules/xac-nhan/xac-nhan.module").then(m => m.XacNhanModule)
      }
    ]
  },
  {
    path: "login",
    loadChildren: () => 
      import('./modules/login/login.module').then(m => m.LoginModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
