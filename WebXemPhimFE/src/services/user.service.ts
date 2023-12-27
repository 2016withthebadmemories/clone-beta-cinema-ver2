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
        return this.httpClient.get(environment.baseApiUrl + "TaiKhoan");
    }

    getUserById(id: number) {
        return this.httpClient.get(environment.baseApiUrl + `TaiKhoan/${id}`)
    }

    login(data: Login) {
        return this.httpClient.post<LoginResponse>(environment.baseApiUrl + "TaiKhoan/Login", data)
    }

    register(data: Register) {
        return this.httpClient.post(environment.baseApiUrl + "TaiKhoan", data)
    }
    
}

export interface Login {
    email: string,
    matKhau: string
}

export interface Register {
    email: string,
    matKhau: string,
    soDienThoai: string
}

export interface LoginResponse {
    success: boolean,
    message: string,
    data: string,
    email: string
    maTaiKhoan: number
  }