import { PhongService } from './../../../../../../services/phong.service';
import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { GheDto, GheService } from 'src/services/ghe.service';
import { PhongDto } from 'src/services/phong.service';

@Component({
  selector: 'app-create-edit-ghe',
  templateUrl: './create-edit-ghe.component.html',
  styleUrls: ['./create-edit-ghe.component.css']
})
export class CreateEditGheComponent {
  public ghe: GheDto = {} as GheDto;
  phongs: PhongDto[] = [];
  public maGhe: any;
  selectedFile!: File;
  public trangThai: boolean = true;

  constructor(public matDialogRef: MatDialogRef<CreateEditGheComponent>,
    private gheService: GheService,
    private phongService: PhongService,
    @Inject(MAT_DIALOG_DATA) public data: CreateEditGheDialogData) {
  }
  ngOnInit() {
    this.ghe.tinhTrangGhe = this.trangThai;
    this.getAllPhong();
    if (this.data?.ghe?.maGhe) {
      this.maGhe = this.data.ghe.maGhe;
      this.ghe = this.data.ghe;
    }
  }
  
  onFileSelected(event: any) {
    this.selectedFile = event.target.files[0];
    }
  
  close() {
    this.matDialogRef.close();
  }
  getAllPhong() {
    this.phongService.getAllPhong().subscribe((rs) => {
      this.phongs = rs;
    });
  }
  checkTrangThai() {
    this.trangThai = !this.trangThai;
    this.ghe.tinhTrangGhe = this.trangThai;
  }

  create() {
    const data: GheDto = {
      maGhe: this.ghe.maGhe,
      tenGhe: this.ghe.tenGhe,
      tinhTrangGhe: this.ghe.tinhTrangGhe,
      trangThai: this.ghe.trangThai,
      cot: this.ghe.cot,
      hang: this.ghe.hang,
      maPhong: this.ghe.maPhong,
      tenPhong: this.ghe.tenPhong,
    };
    if (this.ghe.maGhe) {
      this.gheService.editGhe(data).subscribe(rs => {
        this.close()
      })
    } else {
      this.gheService.createGhe(data).subscribe(rs => {
        this.close()
      })
    }
    
  }
}
export interface CreateEditGheDialogData{
  ghe: GheDto
}