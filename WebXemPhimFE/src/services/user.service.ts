import { environment } from './../environments/environment';
import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http'

@Injectable({
    providedIn:'root'
})
export class UserService {
    constructor(private httpClient: HttpClient) {
        
    }

    getUser() {
        return this.httpClient.get<Register[]>(environment.baseApiUrl + "TaiKhoan");
    }

    getUserById(id: number) {
        return this.httpClient.get(environment.baseApiUrl + `TaiKhoan/${id}`)
    }

    login(data: Login) {
        return this.httpClient.post<LoginResponse>(environment.baseApiUrl + "TaiKhoan/Login", data)
    }

    register(data: FormData) {
        return this.httpClient.post(environment.baseApiUrl + "TaiKhoan", data)
    }

    update(data: FormData) {
        return this.httpClient.put(environment.baseApiUrl + "TaiKhoan/update", data)
    }

    doiMatKhau(data: Register) {
        return this.httpClient.put(environment.baseApiUrl + "TaiKhoan/doiMatKhau", data)
    }

    updateKhongAnh(data: updateKhongAnh) {
        return this.httpClient.put(environment.baseApiUrl + "TaiKhoan/updateKhongAnh", data)
    }

    delete(id: number) {
        return this.httpClient.delete(environment.baseApiUrl + `TaiKhoan?id=${id}`);
    }
}

export interface Login {
    email: string,
    matKhau: string
}

export interface Register {
    maTaiKhoan: number,
    email: string,
    matKhau: string,
    soDienThoai: string,
    anhDaiDien: string,
}

export interface updateKhongAnh {
    maTaiKhoan: number,
    email: string,
    matKhau: string,
    soDienThoai: string,
}


export interface LoginResponse {
    success: boolean,
    message: string,
    data: string,
    email: string
    maTaiKhoan: number
  }