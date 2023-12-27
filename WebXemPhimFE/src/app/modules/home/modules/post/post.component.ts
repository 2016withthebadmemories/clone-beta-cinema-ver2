import { PostService } from './../../../../../services/post.service';
import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BinhLuanDto } from 'src/app/modules/admin/modules/comment/list-comment/list-comment.component';
import { CommentService } from 'src/services/comment.service';
import { XuatChieuService, XuatChieuDto, XuatChieuRequest } from 'src/services/xuatChieu.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent {

  id: number = 0;
  public phim: PhimDto = {} as PhimDto;
  public xuatchieurequest: XuatChieuRequest = {} as XuatChieuRequest;
  public comment: BinhLuanDto[] = [];
  public xuatChieus: XuatChieuDto[] = [];
  public ngayTiepTheo: any[] = []; 
  selectedItem: any = null;
  constructor(
    private postService: PostService,
    private activatedRoute: ActivatedRoute,
    private commentService: CommentService,
    private xuatChieuService: XuatChieuService
  ) { }
  
  ngOnInit() {
    this.activatedRoute.params.subscribe(s => {
      this.getNgayTiepTheo();
      this.id = s['id']
      this.getAllComment(this.id);
      this.postService.getPostById(this.id).subscribe(x => {
        this.phim = x
      })
    })
  }
  
  selectItem(item: any) {
    if (this.selectedItem === item) {
      this.selectedItem = null;
    } else {
      this.selectedItem = item;
      this.getXuatChieuByPhimId(this.selectedItem.getDate(), this.selectedItem.getMonth()+1 , this.selectedItem.getFullYear(), this.id);
    }
  }

  getNgayTiepTheo() {
    this.ngayTiepTheo = [];
    let ngayHienTai = new Date();
    for (let i = 0; i < 5; i++) {
        this.ngayTiepTheo.push(new Date(ngayHienTai));
      ngayHienTai.setDate(ngayHienTai.getDate() + 1);
    }
}

  getAllComment(id: number) {
    this.postService.getComment(id).subscribe((rs) => {
      this.comment = rs;
    });
  }

  getXuatChieuByPhimId(ngay: number, thang: number, nam: number, maPhim: number) {
    this.xuatchieurequest = {
      ngay: ngay,
      thang: thang,
      nam: nam,
      maPhim: maPhim,
    }
    this.xuatChieuService.getXuatChieuByPhimId(this.xuatchieurequest).subscribe((rs) => {
      this.xuatChieus = rs;
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
