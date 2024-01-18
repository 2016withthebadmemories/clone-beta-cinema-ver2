import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Register, UserService } from 'src/services/user.service';
import { CreateEditUserComponent } from '../create-edit-user/create-edit-user.component';
import { XacNhanComponent } from '../../xac-nhan/xac-nhan.component';

@Component({
  selector: 'app-list-user',
  templateUrl: './list-user.component.html',
  styleUrls: ['./list-user.component.css']
})
export class ListUserComponent {
  public user: Register[] = [];
  constructor(private userService: UserService, private dialog: MatDialog) {}

  ngOnInit() {
    this.getAllUser();
  }
  getAllUser() {
    this.userService.getUser().subscribe((rs) => {
      this.user = rs;
    });
  }
  create() {
    const dialogRef = this.dialog.open(CreateEditUserComponent, {});
    dialogRef.afterClosed().subscribe((rs) => {
      this.getAllUser();
    });
  }
  edit(item: Register) {
    const dialogRef = this.dialog.open(CreateEditUserComponent, {
      data: {
        user: JSON.parse(JSON.stringify(item)),
      },
    });
    dialogRef.afterClosed().subscribe((rs) => {
      this.getAllUser();
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
        this.userService.delete(id).subscribe((rs) => {
          this.getAllUser();
        });
      }
    });
  }
}
