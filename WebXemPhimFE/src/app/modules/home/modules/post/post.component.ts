import { PostService } from './../../../../../services/post.service';
import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BinhLuanDto } from 'src/app/modules/admin/modules/comment/list-comment/list-comment.component';
import { CommentService } from 'src/services/comment.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent {

  id: number = 0;
  public phim: PhimDto = {} as PhimDto;
  public comment: BinhLuanDto[] = [];

  constructor(
    private postService: PostService,
    private activatedRoute: ActivatedRoute,
    private commentService: CommentService
  ) { }
  
  ngOnInit() {
    this.activatedRoute.params.subscribe(s => {
      this.id = s['id']
      this.getAllComment(this.id);
      this.postService.getPostById(this.id).subscribe(x => {
        this.phim = x
      })
    })
  }
  getAllComment(id: number) {
    this.postService.getComment(id).subscribe((rs) => {
      this.comment = rs;
    });
  }
}
export interface PhimDto {
  maPhim: number,
  tenPhim: string,
  moTa: string,
  dienVien: string,
  daodien: string,
  gia: number,
  anhPhim: string;
  ngayBatDau: string;
  ngayKetThuc: string;
  quocGia: string;
  hangPhim: string;
  phienBan: string;
  theLoai: string;
  trangThai: boolean;
  maRap: string;
  thoiLuong: string;
}
