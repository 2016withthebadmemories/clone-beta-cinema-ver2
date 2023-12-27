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

  constructor(private userService: UserService, private authService:AuthService, private router: Router) {
    
  }
  ngOnInit() {
    
  }

  submit(event: any) {
    event.preventDefault();
    const data = {
      email: this.email,
      matKhau: this.matKhau,
      soDienThoai: this.soDienThoai
    }
      this.userService.register(data).subscribe(rs => {
        this.router.navigateByUrl("/home/login")
      })
  }
}
