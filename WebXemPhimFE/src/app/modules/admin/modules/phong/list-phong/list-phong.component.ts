import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PhongDto, PhongService } from 'src/services/phong.service';
import { CreateEditPhongComponent } from '../create-edit-phong/create-edit-phong.component';
import { XacNhanComponent } from '../../xac-nhan/xac-nhan.component';

@Component({
  selector: 'app-list-phong',
  templateUrl: './list-phong.component.html',
  styleUrls: ['./list-phong.component.css']
})
export class ListPhongComponent {
  public phong: PhongDto[] = [];
  constructor(private phongService: PhongService, private dialog: MatDialog) {}

  ngOnInit() {
    this.getAllPhong();
  }
  getAllPhong() {
    this.phongService.getAllPhong().subscribe((rs) => {
      this.phong = rs;
    });
  }
  create() {
    const dialogRef = this.dialog.open(CreateEditPhongComponent, {});
    dialogRef.afterClosed().subscribe((rs) => {
      this.getAllPhong();
    });
  }
  edit(item: PhongDto) {
    const dialogRef = this.dialog.open(CreateEditPhongComponent, {
      data: {
        phong: JSON.parse(JSON.stringify(item)),
      },
    });
    dialogRef.afterClosed().subscribe((rs) => {
      this.getAllPhong();
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
        this.phongService.delete(id).subscribe((rs) => {
          this.getAllPhong();
        });
      }
    });
  }
}
