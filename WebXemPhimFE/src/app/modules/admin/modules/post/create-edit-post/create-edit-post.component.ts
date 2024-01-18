import { topicDto } from './../../topic/list-topic/list-topic.component';
import { Component, Inject, Input } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { PhimDto, xuatChieuPhim } from 'src/app/modules/home/modules/post/post.component';
import { PostService } from 'src/services/post.service';
import { RapDto, RapService } from 'src/services/rap.service';
import { TopicService } from 'src/services/topic.service';
import {FormGroup, FormControl, FormsModule, ReactiveFormsModule} from '@angular/forms';
import { DateRangeFormService } from 'src/services/dateRangeForm.service';
import { actionCreateEditPopup } from 'src/type';
import { initTime } from 'helper';
import { catchError, concatMap, of, throwError, timeout } from 'rxjs';

@Component({
  selector: 'app-create-edit-post',
  templateUrl: './create-edit-post.component.html',
  styleUrls: ['./create-edit-post.component.css'],
})
export class CreateEditPostComponent {
  public post: PhimDto = {} as PhimDto;
  public listMaRap: number[] = [];
  @Input() action: actionCreateEditPopup = actionCreateEditPopup.Create; 
  raps: RapDto[] = [];
  selectedFile!: File;
  trangThai: boolean = false;
  constructor(
    public matDialogRef: MatDialogRef<CreateEditPostComponent>,
    private postService: PostService,
    @Inject(MAT_DIALOG_DATA) public data: CreateEditPostDialogData,
    private rapService: RapService,
    public dateRangeFormService: DateRangeFormService,
  ) {}
  ngOnInit() {
    this.post.trangThai = this.trangThai;
    this.dateRangeFormService.buildForm();
    this.post.trangThai = this.trangThai;
    if (this.data?.post?.maPhim) {
      // this.dateRangeFormService.rangeForm_start.setValue(this.data.post.ngayBatDau);
      // this.dateRangeFormService.rangeForm_end.setValue(this.data.post.ngayKetThuc);
      this.post = this.data.post;
    }
    this.getAllRap();
    console.log(initTime());
  }

  onFileSelected(event: any) {
  this.selectedFile = event.target.files[0];
  }

  getAllRap() {
    this.rapService.getAllRap().subscribe((rs) => {
      this.raps = rs;
    });
  }

  close() {
    this.matDialogRef.close();
  }

  checkTrangThai() {
    this.trangThai = !this.trangThai;
    this.post.trangThai = this.trangThai;
  }

  

  create() {
    // this.post.ngayBatDau = new Date(this.dateRangeFormService.rangeForm_start.value).toISOString();
    // this.post.ngayKetThuc = new Date(this.dateRangeFormService.rangeForm_end.value).toISOString();
    const formData = new FormData();
    if (this.post.maPhim) {
      formData.append('maPhim', this.post?.maPhim?.toString());
    }
    if (this.selectedFile) {
      formData.append('anhPhimFile', this.selectedFile, this.selectedFile.name);  
    }
    if (this.post.maRap) {
      formData.append('maRap', this.post?.maRap?.toString());
    }
    formData.append('tenPhim', this.post.tenPhim);
    formData.append('moTa', this.post.moTa);
    formData.append('dienVien', this.post.dienVien);
    formData.append('daodien', this.post.daodien);
    formData.append('gia', this.post.gia.toString());
    // formData.append('ngayBatDau', this.post.ngayBatDau);
    // formData.append('ngayKetThuc', this.post.ngayKetThuc);
    formData.append('quocGia', this.post.quocGia);
    formData.append('hangPhim', this.post.hangPhim);
    formData.append('phienBan', this.post.phienBan);
    formData.append('linkTrailer', this.post.linkTrailer);
    formData.append('theLoai', this.post.theLoai);
    formData.append('trangThai', this.post.trangThai.toString());
    formData.append('thoiLuong', this.post.thoiLuong);
    formData.append('tenRap', this.post.tenRap);
  
    if (this.listMaRap.length > 0) {
      of(...this.listMaRap).pipe(
        concatMap((maRap) => {
          const formDataClone = this.cloneFormDataWithMaRap(formData, maRap);
  
          return this.postService.createPost(formDataClone).pipe(
            timeout(5000),
            catchError((error) => {
              console.error('API call error:', error);
              return throwError(error);
            })
          );
        })
      ).subscribe(
        (rs) => {
          console.log('API call success:', rs);
        },
        (error) => {
          console.error('Error:', error);
        },
        () => {
          this.close();
        }
      );
    } else if (this.post.maPhim) {
      this.postService.editPost(formData).subscribe(
        (rs) => {
          console.log('Edit API call success:', rs);
          this.close();
        },
        (error) => {
          console.error('Edit API call error:', error);
        }
      );
    }
  }
  private cloneFormDataWithMaRap(originalFormData: FormData, maRap: number): FormData {
    const formDataClone = new FormData();
    originalFormData.forEach((value, key) => {
      formDataClone.append(key, value);
    });
    formDataClone.append('maRap', maRap.toString());
    return formDataClone;
  }
  content = '';
  init = {
    height: 500,
    branding: false,
    plugins:
      'advlist autolink lists link image charmap print preview hr anchor pagebreak',
    toolbar:
      'undo redo | styleselect | bold italic underline strikethrough | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image',
    image_title: true,
    image_caption: true,
    image_dimensions: false,
    image_class_list: [
      { title: 'None', value: '' },
      { title: 'Responsive', value: 'img-responsive' },
    ],
  };
}

export interface CreateEditPostDialogData {
  post: PhimDto;
}

