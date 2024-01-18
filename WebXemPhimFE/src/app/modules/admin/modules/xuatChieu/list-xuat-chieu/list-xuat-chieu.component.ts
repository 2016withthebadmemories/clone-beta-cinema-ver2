import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { XuatChieuDto, XuatChieuService } from 'src/services/xuatChieu.service';
import { CreateEditXuatChieuComponent } from '../create-edit-xuat-chieu/create-edit-xuat-chieu.component';
import { XacNhanComponent } from '../../xac-nhan/xac-nhan.component';

@Component({
  selector: 'app-list-xuat-chieu',
  templateUrl: './list-xuat-chieu.component.html',
  styleUrls: ['./list-xuat-chieu.component.css']
})
export class ListXuatChieuComponent {
  public xc: XuatChieuDto[] = [];
  
  constructor(private xuatChieuService: XuatChieuService, private dialog: MatDialog) {}
  ngOnInit() {
    this.getAllXuatChieu();
  }
  getAllXuatChieu() {
    this.xuatChieuService.getAllXuatChieu().subscribe((rs) => {
      this.xc = rs;
    });
  }
  create() {
    const dialogRef = this.dialog.open(CreateEditXuatChieuComponent, {});
    dialogRef.afterClosed().subscribe((rs) => {
      this.getAllXuatChieu();
    });
  }
  edit(item: XuatChieuDto) {
    const dialogRef = this.dialog.open(CreateEditXuatChieuComponent, {
      data: {
        xc: JSON.parse(JSON.stringify(item)),
      },
    });
    dialogRef.afterClosed().subscribe((rs) => {
      this.getAllXuatChieu();
    });
  }
  delete(id: number) {
    this.openDeleteConfirmationDialog(id);
  }
  
  openDeleteConfirmationDialog(id: number): void {
    const dialogRef = this.dialog.open(XacNhanComponent, {
      width: '300px', // You can adjust the width as needed
    });
  
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.xuatChieuService.delete(id).subscribe((rs) => {
          this.getAllXuatChieu();
        });
      }
    });
  }
}
