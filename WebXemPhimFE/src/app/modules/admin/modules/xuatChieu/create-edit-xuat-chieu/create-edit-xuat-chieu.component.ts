import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { PhimDto, xuatChieuCreateForPhim, xuatChieuEditForPhim } from 'src/app/modules/home/modules/post/post.component';
import { PhongDto, PhongService } from 'src/services/phong.service';
import { PostService } from 'src/services/post.service';
import { XuatChieuDto, XuatChieuService } from 'src/services/xuatChieu.service';

@Component({
  selector: 'app-create-edit-xuat-chieu',
  templateUrl: './create-edit-xuat-chieu.component.html',
  styleUrls: ['./create-edit-xuat-chieu.component.css']
})
export class CreateEditXuatChieuComponent {
  public xc: XuatChieuDto = {} as XuatChieuDto;
  public maXuatChieu: any;
  public xuatChieuFg: FormGroup = this.formBuilder.group({
    maPhim: null,
    maPhong: null,
    xuatChieus: this.formBuilder.array([
      this.formBuilder.group({
        gio: null,
        phut: null,
        ngayChieu: null
      })
    ]),
    gio: null,
    phut: null,
    ngayChieu: null,
    id: null
  });

  selectedFile!: File;
  public post: PhimDto[] = [];
  phongs: PhongDto[] = [];
  public xuatChieus: any[] = [{}]; // Mảng để lưu trữ các khối ngày chiếu, giờ và phút

  constructor(public matDialogRef: MatDialogRef<CreateEditXuatChieuComponent>,
    private xuatChieuService: XuatChieuService,
    private postService: PostService,
    private phongService: PhongService,
    private formBuilder: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public data: CreateEditXuatChieuDialogData) {
  }

  ngOnInit() {
    if (this.data?.xc?.maXuatChieu) {
      this.maXuatChieu = this.data.xc.maXuatChieu;
      this.xc = this.data.xc;
      this.xuatChieuFg.patchValue({
        ...this.xc
      })
      this.xuatChieuFg.get('maPhong').disable();
      this.xuatChieuFg.get('maPhim').disable();
    }
    this.getAllPhim();
    this.getAllPhong();
  }

  getAllPhong() {
    this.phongService.getAllPhong().subscribe((rs) => {
      this.phongs = rs;
    });
  }

  onFileSelected(event: any) {
    this.selectedFile = event.target.files[0];
  }

  close() {
    this.matDialogRef.close();
  }

  getAllPhim() {
    this.postService.getAllPhimAdmin().subscribe((rs) => {
      this.post = rs;
    });
  }

  addBlock() {
    this.xuatChieus.push({});
  }

  addXuatChieuToBlock() {
    const newCuc = {
      ngayChieu: new Date(this.xc.ngayChieu),
      gio: this.xc.gio,
      phut: this.xc.phut,
    };

    this.xuatChieus[this.xuatChieus.length - 1] = newCuc;
  }

  removeBlock(index: number) {
    this.xuatChieus.splice(index, 1);
  }

  create() {
    // const data: xuatChieuCreateForPhim = {
    //   maPhim: this.xc.maPhim,
    //   maPhong: this.xc.maPhong,
    //   xuatChieus: this.xuatChieus,
    // };
    const data = this.xuatChieuFg.getRawValue() as xuatChieuCreateForPhim;
    const dataEdit: xuatChieuEditForPhim = {
      maXuatChieu: this.xc.maXuatChieu,
      gio: parseInt(this.xuatChieuFg.get('gio').value),
      phut: parseInt(this.xuatChieuFg.get('phut').value),
    };

    if (this.xc.maXuatChieu) {
      this.postService.editXuatChieuForPhim(dataEdit).subscribe(() => {
        this.close();
      });
    } else {
      this.postService.createXuatChieuForPhim(data).subscribe(() => {
        this.close();
      });
    }
  }
  public get xuatChieuArray() {
    return (this.xuatChieuFg.get('xuatChieus') as FormArray<FormGroup>)
  }

  public addGroup() {
    this.xuatChieuArray.controls.push(this.formBuilder.group({
      gio: null,
      phut: null,
      ngayChieu: null
    }))
  }

  public removeGroup(index) {
    this.xuatChieuArray.removeAt(index)
  }
}



export interface CreateEditXuatChieuDialogData {
  xc: XuatChieuDto;
}
