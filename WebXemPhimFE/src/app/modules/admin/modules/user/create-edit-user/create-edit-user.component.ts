import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Register, UserService, updateKhongAnh } from 'src/services/user.service';

@Component({
  selector: 'app-create-edit-user',
  templateUrl: './create-edit-user.component.html',
  styleUrls: ['./create-edit-user.component.css']
})
export class CreateEditUserComponent {
  public user: Register = {} as Register;
  public maTaiKhoan: any;
  selectedFile!: File;
  constructor(public matDialogRef: MatDialogRef<CreateEditUserComponent>,
    private userService: UserService,
    @Inject(MAT_DIALOG_DATA) public data: CreateEditUserDialogData) {
  }
  ngOnInit() {
    if (this.data?.user?.maTaiKhoan) {
      this.maTaiKhoan = this.data.user.maTaiKhoan;
      this.user = this.data.user;
    }
  }
  
  onFileSelected(event: any) {
    this.selectedFile = event.target.files[0];
    }
  
  close() {
    this.matDialogRef.close();
  }

  create() {
    const formData = new FormData();
    if (this.user.maTaiKhoan) { 
      formData.append('maTaiKhoan', this.user.maTaiKhoan.toString());
    }
    if (this.selectedFile) {
      formData.append('anh', this.selectedFile, this.selectedFile.name);
    }
    formData.append('soDienThoai', this.user.soDienThoai);
    formData.append('email', this.user.email);
    formData.append('matKhau', this.user.matKhau);
    const data: updateKhongAnh = {
      maTaiKhoan: this.user.maTaiKhoan,
      soDienThoai: this.user.soDienThoai,
      email: this.user.email,
      matKhau: this.user.matKhau,
    };
    if (this.user.maTaiKhoan) {
      this.userService.updateKhongAnh(data).subscribe(rs => {
        this.close()
      })
    } else {
      this.userService.register(formData).subscribe(rs => {
        this.close()
      })
    }
    
  }
}
export interface CreateEditUserDialogData{
  user: Register
}