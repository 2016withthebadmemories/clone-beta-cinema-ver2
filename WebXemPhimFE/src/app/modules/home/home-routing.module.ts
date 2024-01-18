import { HomeComponent } from './home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeIndexComponent } from './components/home-index/home-index.component';
import { SearchComponent } from './components/search/search.component';
import { LoginComponent } from './modules/login/login.component';
import { RegisterComponent } from './modules/register/register.component';
import { RapComponent } from './modules/rap/rap.component';
import { DatVeComponent } from '../admin/modules/dat-ve/dat-ve.component';
import { GiaVeComponent } from './modules/gia-ve/gia-ve.component';
import { UserComponent } from './modules/user/user.component';
import { KhuyenMaiComponent } from './modules/khuyen-mai/khuyen-mai.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    children: [
      {
        path: "",
        component: HomeIndexComponent
      },
      {
        path: 'search',
        component: SearchComponent
      },
      {
        path: 'post',
        loadChildren: () =>
          import('./modules/post/post.module').then((m) => m.PostModule),
      },
      {
        path: 'topic',
        loadChildren: () =>
          import('./modules/topic/topic.module').then((m) => m.TopicModule),
      },
      {
        path: 'dat-ve',
        loadChildren: () =>
          import('../admin/modules/dat-ve/datVe.module').then((m) => m.DatVeModule),
      },
      {
        path: "login",
        component: LoginComponent
      },
      {
        path: "rap",
        component: RapComponent
      },
      {
        path: "ve",
        component: GiaVeComponent
      },
      {
        path: "user",
        component: UserComponent
      },
      {
        path: "khuyen-mai",
        component: KhuyenMaiComponent
      },
      {
        path: "register",
        component: RegisterComponent
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class HomeRoutingModule {}
