import { Component, EventEmitter, Output } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-xac-nhan',
  templateUrl: './xac-nhan.component.html',
  styleUrls: ['./xac-nhan.component.css']
})
export class XacNhanComponent {
  constructor(public dialogRef: MatDialogRef<XacNhanComponent>) {}


  onNoClick(): void {
    this.dialogRef.close();
  }
}
