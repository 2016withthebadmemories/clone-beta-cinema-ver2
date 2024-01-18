import { environment } from './../environments/environment';
import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http'

@Injectable({
    providedIn:'root'
})
export class PhongService {
    constructor(private httpClient: HttpClient) {
        
    }

    getAllPhong() {
        return this.httpClient.get<PhongDto[]>(environment.baseApiUrl + "Phong");
    }
    getPhongById(id: number) {
        return this.httpClient.get<PhongDto>(environment.baseApiUrl + `Phong/${id}`)
    }
    createPhong(data: PhongDto) {
        return this.httpClient.post(environment.baseApiUrl + "Phong", data)
    }
    editPhong(data: PhongDto) {
        return this.httpClient.put(environment.baseApiUrl + "Phong", data)
    }
    delete(id: number) {
        return this.httpClient.delete(environment.baseApiUrl + `Phong?id=${id}`);
    }
}

export interface PhongDto{
    maPhong: number;
    tenPhong: string;
    trangThai: boolean;
    ghiChu: string,
    soLuongGhe: number;
}