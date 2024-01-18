import { environment } from './../environments/environment';
import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http'

@Injectable({
    providedIn:'root'
})
export class XuatChieuService {
    constructor(private httpClient: HttpClient) {
        
    }

    getAllXuatChieu() {
       return this.httpClient.get<XuatChieuDto[]>(environment.baseApiUrl + "XuatChieu");
    }

    getXuatChieuByPhimId(model: XuatChieuRequest) {
        return this.httpClient.post<XuatChieuDto[]>(`${environment.baseApiUrl}XuatChieu/byPhim`, model);
    }    
    createXuatChieu(data: XuatChieuDto) {
        return this.httpClient.post<XuatChieuDto>(environment.baseApiUrl + "XuatChieu", data)
    }
    editXuatChieu(data: XuatChieuDto) {
        return this.httpClient.put<XuatChieuDto>(environment.baseApiUrl + "XuatChieu", data)
    }
    delete(id: number) {
        return this.httpClient.delete(environment.baseApiUrl + `XuatChieu?id=${id}`);
    }
}

export interface XuatChieuDto{
    maXuatChieu: number;
    ngayChieu: string;
    phut: string;
    gio: string;
    maPhim: number;
    tenPhim: string;
    tenRap: string;
    tenPhong: string;
    maPhong: number;
}

export interface XuatChieuRequest{
    ngay: number;
    thang: number;
    nam: number;
    maPhim: number;
  }