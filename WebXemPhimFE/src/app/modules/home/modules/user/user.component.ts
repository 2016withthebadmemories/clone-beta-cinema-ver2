import { DatVeService } from 'src/services/datVe.service';
import { UserService } from 'src/services/user.service';
import { Component } from '@angular/core';
import { map } from 'rxjs';
import { scrollToTop } from 'helper';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent {
  constructor(
    private userService: UserService,
    private datVeService: DatVeService
  ) { }
  selectedFile!: File;
  showEditForm: boolean = false;
  editedUser: any = {};
  veHistory: any = [];
  user: any = {};
  ngOnInit() {
    this.getUserInfo();
    scrollToTop();
    this.GetDatVeHistoryByMaTaiKhoan();
  }

  localUser: any = localStorage.getItem('maTaiKhoan');
  getUserInfo() {
    this.userService.getUserById(this.localUser).subscribe(res => {
      this.user = res;
    })
  }
  toggleEditForm() {
    this.showEditForm = !this.showEditForm;
  }
  onFileSelected(event: any) {
    this.selectedFile = event.target.files[0];
  }
  
  GetDatVeHistoryByMaTaiKhoan() {
    this.datVeService.GetDatVeHistoryByMaTaiKhoan(this.localUser).subscribe((rs) => {
      this.veHistory = rs;
    });
  }

  onSubmit() {
    const formData = new FormData();
    formData.append('maTaiKhoan', this.localUser);
    formData.append('soDienThoai', this.editedUser.soDienThoai);  
    formData.append('email', this.editedUser.email);
    formData.append('matKhau', this.editedUser.matKhau);
    if (this.selectedFile) {
      formData.append('anh', this.selectedFile, this.selectedFile.name);  
    }
    // Assuming you have an update method in your service
    this.userService.update(formData).subscribe(updatedUser => {
      this.getUserInfo();
    });
  }
}
