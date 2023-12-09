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
}

export interface Login {
    userName: string,
    password: string
}

export interface LoginResponse {
    success: boolean,
    message: string,
    data: string,
  }