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
// register Swiper custom elements
register();

@NgModule({
  declarations: [HomeComponent, HomeIndexComponent, TopicComponent, SearchComponent, LoginComponent, RegisterComponent],
  imports: [
    CommonModule,
    HomeRoutingModule,
    FormsModule
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]

})
export class HomeModule {
  
 }
