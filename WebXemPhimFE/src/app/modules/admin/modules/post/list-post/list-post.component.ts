import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PhimDto } from 'src/app/modules/home/modules/post/post.component';
import { PostService } from 'src/services/post.service';
import { CreateEditPostComponent } from '../create-edit-post/create-edit-post.component';
import { DateRangeFormService } from 'src/services/dateRangeForm.service';
import { XacNhanComponent } from '../../xac-nhan/xac-nhan.component';
import { RapDto, RapService } from 'src/services/rap.service';
import { SuKienGiaComponent } from '../su-kien-gia/su-kien-gia.component';
@Component({
  selector: 'app-list-post',
  templateUrl: './list-post.component.html',
  styleUrls: ['./list-post.component.css']
})
export class ListPostComponent {
  public maRap: number | null = null;
  public ngayTao: Date | null = null;
  public trangThai: boolean | null = null;
  public tenPhim: string | null = null;
  public daodien: string | null = null;
  public hangPhim: string | null = null;
  public quocGia: string | null = null;
  public post: PhimDto[] = [];
  raps: RapDto[] = [];

  constructor(private postService: PostService,
    private rapService: RapService, private dialog: MatDialog, public dateRangeFormService: DateRangeFormService) { }

  ngOnInit() {
    this.getAllPhim();
    this.getAllRap();
    
  }
  getAllRap() {
    this.rapService.getAllRap().subscribe((rs) => {
      this.raps = rs;
    });
  }

  clearInputs() {
    // Đặt giá trị các biến về null hoặc giá trị mặc định của chúng
    this.ngayTao = null;
    this.maRap = null;
    this.trangThai = null;
    this.tenPhim = null;
    this.daodien = null;
    this.hangPhim = null;
    this.quocGia = null;
    // Gọi lại hàm search() nếu cần
    this.search();
  }

  search() {
    this.getAllPhim()
  }
  getAllPhim() {
    this.postService.getAllPhimAdmin({
      maRap: this.maRap,
      ngayTao: this.ngayTao,
      trangThai: this.trangThai,
      tenPhim: this.tenPhim,
      daodien: this.daodien,
      hangPhim: this.hangPhim,
      quocGia: this.quocGia
    }).subscribe((rs) => {
      this.post = rs;
    });
  }

  capNhatGia() {
    const dialogRef = this.dialog.open(SuKienGiaComponent, {
      data: {
        rap: JSON.parse(JSON.stringify(this.raps)),
      },
      width: '900px'
    });
    
    dialogRef.afterClosed().subscribe((rs) => {
      this.getAllPhim();
    });
  }

  create() {
    const dialogRef = this.dialog.open(CreateEditPostComponent, {});
    dialogRef.afterClosed().subscribe((rs) => {
      this.getAllPhim();
    });
  }
  edit(item: PhimDto) {
    const dialogRef = this.dialog.open(CreateEditPostComponent, {
      data: {
        post: JSON.parse(JSON.stringify(item)),
      },
      width: '900px'
    });
    
    dialogRef.afterClosed().subscribe((rs) => {
      this.getAllPhim();
    });
  }

  deletePost(id: number) {
    this.openDeleteConfirmationDialog(id);
  }
  
  openDeleteConfirmationDialog(id: number): void {
    const dialogRef = this.dialog.open(XacNhanComponent, {
      width: '300px', // You can adjust the width as needed
    });
  
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.postService.delete(id).subscribe((rs) => {
          this.getAllPhim();
        });
      }
    });
  }
}