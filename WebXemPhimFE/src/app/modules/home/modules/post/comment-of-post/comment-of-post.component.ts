import { Component, Input } from '@angular/core';
import { BinhLuanDto } from 'src/app/modules/admin/modules/comment/list-comment/list-comment.component';
import { CommentService } from 'src/services/comment.service';
import { PostService } from 'src/services/post.service';

@Component({
  selector: 'app-comment-of-post',
  templateUrl: './comment-of-post.component.html',
  styleUrls: ['./comment-of-post.component.css']
})
export class CommentOfPostComponent {
  
  @Input() comments: BinhLuanDto[] = [];
  public name: string = '';
  public email: string = '';
  public comment: string = '';
  public ngayBinhLuan: string = '';
  commentContent = '';
  @Input() id: number = 0;

  constructor(
    private commentService: CommentService,
    private postService: PostService,
  ) { }

  onSubmit() {
    const maTaiKhoan = localStorage.getItem("maTaiKhoan");
    const comment = {
      noiDung: this.comment,
      maPhim: this.id,
      maTaiKhoan: maTaiKhoan,
    } as BinhLuanDto;
    this.commentService.createComment(comment).subscribe(s => {
      this.GetAll();
    });
  }

  ngOnInit() {
    this.GetAll();
  }
  GetAll() {
    this.postService.getComment(this.id).subscribe(s => 
      {
        this.comments = s;  
      });
  }
  
}
