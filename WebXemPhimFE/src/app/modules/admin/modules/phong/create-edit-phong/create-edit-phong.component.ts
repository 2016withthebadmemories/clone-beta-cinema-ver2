import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { PhongDto, PhongService } from 'src/services/phong.service';

@Component({
  selector: 'app-create-edit-phong',
  templateUrl: './create-edit-phong.component.html',
  styleUrls: ['./create-edit-phong.component.css']
})
export class CreateEditPhongComponent {
  public phong: PhongDto = {} as PhongDto;
  public maPhong: any;
  selectedFile!: File;
  public trangThai: boolean = true;
  constructor(public matDialogRef: MatDialogRef<CreateEditPhongComponent>,
    private PhongService: PhongService,
    @Inject(MAT_DIALOG_DATA) public data: CreateEditPhongDialogData) {
  }
  ngOnInit() {
    this.phong.trangThai = this.trangThai;
    if (this.data?.phong?.maPhong) {
      this.maPhong = this.data.phong.maPhong;
      this.phong = this.data.phong;
    }
  }
  checkTrangThai() {
    this.trangThai = !this.trangThai;
    this.phong.trangThai = this.trangThai;
  }

  onFileSelected(event: any) {
    this.selectedFile = event.target.files[0];
    }
  
  close() {
    this.matDialogRef.close();
  }

  create() {
    const data: PhongDto = {
      maPhong: this.phong.maPhong,
      tenPhong: this.phong.tenPhong,
      trangThai: this.phong.trangThai,
      ghiChu: this.phong.ghiChu,
      soLuongGhe: this.phong.soLuongGhe,
    };
    if (this.phong.maPhong) {
      this.PhongService.editPhong(data).subscribe(rs => {
        this.close()
      })
    } else {
      this.PhongService.createPhong(data).subscribe(rs => {
        this.close()
      })
    }
    
  }
}
export interface CreateEditPhongDialogData{
  phong: PhongDto
}