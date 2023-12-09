import { MatDialog } from '@angular/material/dialog';
import { CommentService } from './../../../../../../services/comment.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-list-comment',
  templateUrl: './list-comment.component.html',
  styleUrls: ['./list-comment.component.css']
})
export class ListCommentComponent {
  public comment: BinhLuanDto[] = [];
  constructor(private commentService: CommentService, private dialog:MatDialog) { }
  
  ngOnInit() {
    this.getAllTopic();
  }
  getAllTopic() {
    this.commentService.getAllComment().subscribe(rs => {
      this.comment = rs;
    })
  }
  deleteComment(id: number) {
    this.commentService.delete(id).subscribe((rs) => {
      this.getAllTopic();
    });
  }
}
export interface BinhLuanDto{
  maBinhLuan: number;
  noiDung: string;
  ngayBinhLuan: string;
  maTaiKhoan: string;
  maPhim: number;
}