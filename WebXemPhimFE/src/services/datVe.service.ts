import { environment } from './../environments/environment';
import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http'

@Injectable({
    providedIn:'root'
})
export class DatVeService {
    constructor(private httpClient: HttpClient) {
        
    }

    datVe(data: DatVeDto) {
       return this.httpClient.post(environment.baseApiUrl + "DatVe", data);
    }

    GetAllVe() {
        return this.httpClient.get<ListVeDto[]>(environment.baseApiUrl + "DatVe/GetAllDatVeInfo");
    }
    
    GetDatVeInfoById(data: any) {
        return this.httpClient.get(environment.baseApiUrl + "DatVe/GetDatVeInfoById", data);
    }
    GetDatVeHistoryByMaTaiKhoan(data: any) {
        return this.httpClient.get(environment.baseApiUrl + `DatVe/GetDatVeHistoryByMaTaiKhoan?maTaiKhoan=${data}`);
    }
    GetDatVeInfoByMaTaiKhoanVaMaXuatChieu(data: any) {
        return this.httpClient.get(environment.baseApiUrl + "DatVe/GetDatVeInfoByMaTaiKhoanVaMaXuatChieu", data);
    }
    GetChart(data: any) {
        return this.httpClient.get(environment.baseApiUrl + `DatVe/lay-danh-sach-phim?ngayChieu=${data}`);
    }
    xoaVe(data: any) {
        return this.httpClient.delete(environment.baseApiUrl + `DatVe?maDatVe=${data}`);
     }
}

export interface DatVeDto{
    maXuatChieu: number;
    maTaiKhoan: number;
    maGhes: number[];
    soLuong: number;
    tongGia: number;
}

export interface ListVeDto{
    maDatve: number;
    soLuong: number;
    ngayDatVe: string;
    tongGia: number;
    email: string;
    ghes: GhedatVeDto[];
    xuatChieu: XuatChieudatVeDto[];
}

export interface GhedatVeDto { 
    tenGhe: string;
    maGhe: number;
}

export interface XuatChieudatVeDto { 
    maXuatChieu: number;
    gio: number;
    phut: number;
    tenPhong: string;
    tenPhim: string;
    tenRap: string;
}