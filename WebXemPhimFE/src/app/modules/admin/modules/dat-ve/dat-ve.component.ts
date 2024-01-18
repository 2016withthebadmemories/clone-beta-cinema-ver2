import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DatVeDto } from 'src/services/datVe.service';

@Component({
  selector: 'app-dat-ve',
  templateUrl: './dat-ve.component.html',
  styleUrls: ['./dat-ve.component.css']
})
export class DatVeComponent {
  constructor(private route: ActivatedRoute, private http: HttpClient) { }
  public anhThanhCong = "https://localhost:5001/images/t%E1%BA%A3i%20xu%E1%BB%91ng.png";
  ngOnInit(): void {
    // Lấy các tham số từ URL
    this.route.queryParams.subscribe(params => {
      this.http.post('https://localhost:5001/api/DatVe', {
        MaXuatChieu: parseInt(localStorage.getItem("maXuatChieu")),
        MaTaiKhoan: parseInt(localStorage.getItem("maTaiKhoanDatVe")),
        MaGhes: JSON.parse(localStorage.getItem("maGhes")),
        SoLuong: parseInt(localStorage.getItem("soLuong")),
        TongGia: parseInt(localStorage.getItem("tongGia"))
      }).subscribe(response => {
        localStorage.removeItem("maTaiKhoanDatVe");
        localStorage.removeItem("maXuatChieu");
        localStorage.removeItem("maGhes");
        localStorage.removeItem("soLuong");
        localStorage.removeItem("tongGia");
      });
    });
  }

}
