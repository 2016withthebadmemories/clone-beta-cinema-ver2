import { MomoService, thanhToanDto } from './../../../../../../services/momo.service';
import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { GheDto, GheService } from 'src/services/ghe.service';
import { PhimDto } from '../post.component';
import { XuatChieuDto } from 'src/services/xuatChieu.service';
import { DatVeDto, DatVeService } from 'src/services/datVe.service';
import { AuthService } from 'src/services/auth.service';

@Component({
  selector: 'app-chon-ghe',
  templateUrl: './chon-ghe.component.html',
  styleUrls: ['./chon-ghe.component.css']
})
export class ChonGheComponent {
  // public ghe: GheDto = {} as GheDto;
  public ghes: GheDto[] = [];
  public listGheSelected: GheDto[] = [];
  public phims: PhimDto = {} as PhimDto;
  public maPhim: any;
  public xc: XuatChieuDto = {} as XuatChieuDto;
  public maXuatChieu: any;
  public tongTien: any;
  public soVeDaChon: any;
  public maPhong: any;
  public isHetGhe: boolean = false;

  readonly gheDaDat: string = "https://localhost:5001/images/seat-buy-normal.png";
  readonly gheChuaDat: string = "https://localhost:5001/images/seat-unselect-normal.png";
  readonly gheDangChon: string = "https://localhost:5001/images/seat-select-normal.png";
  readonly screen: string = "https://localhost:5001/images/ic-screen.png";
  readonly gheVip: string = "https://localhost:5001/images/seat-unselect-vip.png";
  readonly gheVipDangChon: string = "https://localhost:5001/images/seat-select-vip.png";
  readonly gheVipDaDat: string = "https://localhost:5001/images/seat-buy-vip.png";

  constructor(
    private gheService: GheService,
    public matDialogRef: MatDialogRef<ChonGheComponent>,
    @Inject(MAT_DIALOG_DATA) public data: CreateEditChonGheDialogData,
    private datVeService: DatVeService,
    private momoService: MomoService,
    private authService: AuthService
  ) { }
  
  ngOnInit() {
    if (this.data?.phim?.maPhim) {
      this.maPhim = this.data.phim.maPhim;
      this.phims = this.data.phim;
      this.maXuatChieu = this.data.xc.maXuatChieu;
      this.maPhong = this.data.xc.maPhong;
      this.xc = this.data.xc;
    }
    const data = {
      maPhong: this.maPhong,
      maXuatChieu: this.maXuatChieu
    }
    this.getGheByPhongId(data);
  }
  getGheByPhongId(data) {
    this.gheService.getGheByPhongId(data).subscribe((rs) => {
      const coGheChuaDat = rs.some(gh => gh.trangThai === false);
      this.isHetGhe = coGheChuaDat ? false : true;
      this.ghes = rs;
    });
  }
  isGheDangChon(item: GheDto): boolean {
    return this.listGheSelected.includes(item);
  }

  datVePaypal() { 
    const maTaiKhoan = localStorage.getItem("maTaiKhoan");
    const dataThanhToan: any = {
      amount: this.tongTien
    };
    console.log("🚀 ~ ChonGheComponent ~ datVePaypal ~ dataThanhToan:", dataThanhToan);
    this.momoService.thanhToanPaypal(dataThanhToan).subscribe((rs: any) => {
      console.log("🚀 ~ ChonGheComponent ~ this.momoService.thanhToanPaypal ~ rs:", rs);
      if (rs) {
        window.open(rs.url, '_blank');
        const parsedMaTaiKhoan = parseInt(maTaiKhoan);
        
        const data: DatVeDto = {
          maTaiKhoan: parsedMaTaiKhoan,
          maXuatChieu: this.maXuatChieu,
          soLuong: this.listGheSelected.length,
          tongGia: this.tongTien,
          maGhes: this.listGheSelected.map(x => x.maGhe)
        };
        this.authService.setDataVe(data);
  
        // this.datVeService.datVe(data).subscribe((rs) => {
        // });
      }
    });
  }
  datVe() {
    
    const maTaiKhoan = localStorage.getItem("maTaiKhoan");
    const email = localStorage.getItem("email");
    const dataThanhToan: thanhToanDto = {
      fullName: email,
      orderInfo: `Thanh toán ${this.listGheSelected.length} vé cho phim: ${this.phims.tenPhim}`,
      amount: this.tongTien
    };
  
    this.momoService.thanhToan(dataThanhToan).subscribe((rs: any) => {
      if (rs.payUrl) {
        window.open(rs.payUrl, '_blank');
        const parsedMaTaiKhoan = parseInt(maTaiKhoan);
        
        const data: DatVeDto = {
          maTaiKhoan: parsedMaTaiKhoan,
          maXuatChieu: this.maXuatChieu,
          soLuong: this.listGheSelected.length,
          tongGia: this.tongTien,
          maGhes: this.listGheSelected.map(x => x.maGhe)
        };
        this.authService.setDataVe(data);
  
        // this.datVeService.datVe(data).subscribe((rs) => {
        // });
      }
    });
  }

  getGheImageUrl(item: GheDto): string {
    if (item.tinhTrangGhe && !item.trangThai) {
      return this.gheVip;
    } else if (!item.tinhTrangGhe && !item.trangThai) {
      return this.gheChuaDat;
    } else if (item.trangThai) {
      return item.tinhTrangGhe ? this.gheVipDaDat : this.gheDaDat;
    }
    return ''; 
  }
  
  onClickGhe(item: GheDto) {
    if (!item.trangThai) {
      const index = this.listGheSelected.findIndex(selectedGhe => selectedGhe.maGhe === item.maGhe);
  
      if (index !== -1) {
        this.listGheSelected.splice(index, 1);
      } else {
        this.listGheSelected.push(item);
      }
  
      this.tongTien = this.listGheSelected.reduce((total, ghe) => {
        const giaGhe = ghe.tinhTrangGhe ? 1.25 * this.phims.gia : this.phims.gia;
        return total + giaGhe;
      }, 0);
    }
  }
  
  close() {
    this.matDialogRef.close();
  }

}
export interface CreateEditChonGheDialogData {
  phim: PhimDto;
  xc: XuatChieuDto;
}
