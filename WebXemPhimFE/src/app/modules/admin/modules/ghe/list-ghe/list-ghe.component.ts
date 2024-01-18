import { PhongDto, PhongService } from 'src/services/phong.service';
import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { GheDto, GheService } from 'src/services/ghe.service';
import { CreateEditGheComponent } from '../create-edit-ghe/create-edit-ghe.component';
import { XacNhanComponent } from '../../xac-nhan/xac-nhan.component';

@Component({
  selector: 'app-list-ghe',
  templateUrl: './list-ghe.component.html',
  styleUrls: ['./list-ghe.component.css']
})
export class ListGheComponent {
  public ghe: GheDto[] = [];
  public rooms: PhongDto[] = [];
  public selectedRoom: number | null = null;

  constructor(private gheService: GheService, private phongService: PhongService, private dialog: MatDialog) {}

  ngOnInit() {
    this.getAllGheNotPagging();
    this.getAllGhe();
    this.getAllRooms();
  }
  getAllGhe(maPhong?: number | null) {
    this.gheService.getAllGhe(maPhong).subscribe((rs) => {
      this.ghe = rs;
    });
  }
  getAllGheNotPagging() {
    this.gheService.getAllGheNotPagging().subscribe((rs) => {
      this.ghe = rs;
    });
  }
  getAllRooms() {
    this.phongService.getAllPhong().subscribe((rs) => {
      this.rooms = rs;
    });
  }

  onRoomSelected() {
    this.getAllGhe(this.selectedRoom);
  }
  create() {
    const dialogRef = this.dialog.open(CreateEditGheComponent, {});
    dialogRef.afterClosed().subscribe((rs) => {
      this.getAllGhe(this.selectedRoom);
    });
  }
  edit(item: GheDto) {
    const dialogRef = this.dialog.open(CreateEditGheComponent, {
      data: {
        ghe: JSON.parse(JSON.stringify(item)),
      },
    });
    dialogRef.afterClosed().subscribe((rs) => {
      this.getAllGhe(this.selectedRoom);
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
        this.gheService.delete(id).subscribe((rs) => {
          this.getAllGhe();
        });
      }
    });
  }
}
