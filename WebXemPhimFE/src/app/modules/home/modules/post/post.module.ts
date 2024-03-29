import { PostRoutingModule } from './post-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PostComponent } from './post.component';
import { CommentOfPostComponent } from './comment-of-post/comment-of-post.component';
import { FormsModule } from '@angular/forms';
import { ChonGheComponent } from './chon-ghe/chon-ghe.component';



@NgModule({
  declarations: [
    PostComponent,
    CommentOfPostComponent,
    ChonGheComponent,
  ],
  imports: [
    CommonModule,
    PostRoutingModule,
    FormsModule
  ],
  exports: [
    PostComponent
  ]
})
export class PostModule { }
