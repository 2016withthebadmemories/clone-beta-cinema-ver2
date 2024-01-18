import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeIndexComponent } from './components/home-index/home-index.component';
import { TopicComponent } from './modules/topic/topic.component';
import { SearchComponent } from './components/search/search.component';
import { FormsModule } from '@angular/forms';

// import function to register Swiper custom elements
import { register } from 'swiper/element/bundle';
import { LoginComponent } from './modules/login/login.component';
import { RegisterComponent } from './modules/register/register.component';
import { MatDialogModule } from '@angular/material/dialog';
import { UserComponent } from './modules/user/user.component';
import { RapComponent } from './modules/rap/rap.component';
import { GiaVeComponent } from './modules/gia-ve/gia-ve.component';
import { KhuyenMaiComponent } from './modules/khuyen-mai/khuyen-mai.component';
// register Swiper custom elements
register();

@NgModule({
  declarations: [HomeComponent, HomeIndexComponent, TopicComponent, SearchComponent, LoginComponent, RegisterComponent, UserComponent, RapComponent, GiaVeComponent, KhuyenMaiComponent],
  imports: [
    CommonModule,
    HomeRoutingModule,
    FormsModule,
    MatDialogModule,
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]

})
export class HomeModule {
  
 }
