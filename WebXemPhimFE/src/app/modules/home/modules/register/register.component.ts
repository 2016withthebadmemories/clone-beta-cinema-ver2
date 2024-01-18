import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/services/auth.service';
import { UserService } from 'src/services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  email: string = '';
  matKhau: string = '';
  soDienThoai: string = '';
  selectedFile!: File;

  constructor(private userService: UserService, private authService:AuthService, private router: Router) {
    
  }
  ngOnInit() {
    
  }

  onFileSelected(event: any) {
    this.selectedFile = event.target.files[0];
    }
  
  submit(event: any) {
    event.preventDefault();
    const formData = new FormData();
    formData.append('email',this.email);
    formData.append('matKhau', this.matKhau);
    formData.append('soDienThoai', this.soDienThoai);
    formData.append('LoaiTaiKhoan', 'true');
    formData.append('anh', this.selectedFile, this.selectedFile.name);
      this.userService.register(formData).subscribe(rs => {
        this.router.navigateByUrl("/home/login")
      })
  }
}
