import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { RapDto, RapService } from 'src/services/rap.service';
import { CreateEditRapComponent } from '../create-edit-rap/create-edit-rap.component';
import { XacNhanComponent } from '../../xac-nhan/xac-nhan.component';

@Component({
  selector: 'app-list-rap',
  templateUrl: './list-rap.component.html',
  styleUrls: ['./list-rap.component.css']
})
export class ListRapComponent {
  public rap: RapDto[] = [];
  constructor(private rapService: RapService, private dialog: MatDialog) {}

  ngOnInit() {
    this.getAllRap();
  }
  getAllRap() {
    this.rapService.getAllRap().subscribe((rs) => {
      this.rap = rs;
    });
  }
  create() {
    const dialogRef = this.dialog.open(CreateEditRapComponent, {});
    dialogRef.afterClosed().subscribe((rs) => {
      this.getAllRap();
    });
  }
  edit(item: RapDto) {
    const dialogRef = this.dialog.open(CreateEditRapComponent, {
      data: {
        rap: JSON.parse(JSON.stringify(item)),
      },
    });
    dialogRef.afterClosed().subscribe((rs) => {
      this.getAllRap();
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
        this.rapService.delete(id).subscribe(() => {
          this.getAllRap();
        });
      }
    });
  }
}
