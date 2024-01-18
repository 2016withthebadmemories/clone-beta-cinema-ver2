import { MatDialog } from '@angular/material/dialog';
import { CommentService } from './../../../../../../services/comment.service';
import { Component } from '@angular/core';
import { XacNhanComponent } from '../../xac-nhan/xac-nhan.component';

@Component({
  selector: 'app-list-comment',
  templateUrl: './list-comment.component.html',
  styleUrls: ['./list-comment.component.css']
})
export class ListCommentComponent {
  public comment: GetBinhLuanDto[] = [];
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
    this.openDeleteConfirmationDialog(id);
  }
  
  openDeleteConfirmationDialog(id: number): void {
    const dialogRef = this.dialog.open(XacNhanComponent, {
      width: '300px', // You can adjust the width as needed
    });
  
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.commentService.delete(id).subscribe((rs) => {
          this.getAllTopic();
        });
      }
    });
  }
}
export interface BinhLuanDto{
  maBinhLuan: number;
  noiDung: string;
  ngayBinhLuan: string;
  maTaiKhoan: string;
  maPhim: number;
  anhDaiDien: string;
  email: string;
}

export interface GetBinhLuanDto{
  maBinhLuan: number;
  noiDung: string;
  ngayBinhLuan: string;
  maTaiKhoan: string;
  anhDaiDien: string;
  tenPhim: string;
  email: string;
}