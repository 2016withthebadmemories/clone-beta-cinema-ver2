import { Router } from '@angular/router';
import { AuthService } from './../../../../../services/auth.service';
import { Login, UserService } from './../../../../../services/user.service';
import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  email: string = '';
  matKhau: string = '';

  constructor(private userService: UserService, private authService:AuthService, private router: Router) {
    
  }
  ngOnInit() {
    
  }

  submit(event: any) {
    event.preventDefault();
    const data: Login = {
      email: this.email,
      matKhau: this.matKhau
    }
      this.userService.login(data).subscribe(rs => {
        const userInfo = {
          email: rs.email,
          maTaiKhoan: rs.maTaiKhoan
        }
        if (rs.success) {
          this.authService.setToken(rs.data);
          this.authService.setInfo(userInfo);
          this.router.navigateByUrl("/home")
        }
      })
  }
}
