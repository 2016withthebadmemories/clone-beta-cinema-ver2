import { environment } from './../environments/environment';
import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http'

@Injectable({
    providedIn:'root'
})
export class XuanChieuService {
    constructor(private httpClient: HttpClient) {
        
    }

    getAllXuanChieu() {
       return this.httpClient.get<XuatChieuDto[]>(environment.baseApiUrl + "XuanChieu");
    }

    getXuanChieuByPhimId(model: XuatChieuRequest) {
        return this.httpClient.post<XuatChieuDto[]>(`${environment.baseApiUrl}XuanChieu/byPhim`, model);
    }    
    createXuanChieu(data: XuatChieuDto) {
        return this.httpClient.post<XuatChieuDto>(environment.baseApiUrl + "XuanChieu", data)
    }
    delete(id: number) {
        return this.httpClient.delete(environment.baseApiUrl + `XuanChieu?id=${id}`);
    }
}

export interface XuatChieuDto{
    maXuatChieu: number;
    ngayChieu: string;
    phut: string;
    gio: string;
    maPhim: number;
}
  
export interface XuatChieuRequest{
    ngay: number;
    thang: number;
    nam: number;
    maPhim: number;
  }