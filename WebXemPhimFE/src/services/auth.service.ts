import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http'
import {BehaviorSubject} from 'rxjs'
import { DatVeDto } from "./datVe.service";

@Injectable({
    providedIn:'root'
})
export class AuthService {
    public authToken$: BehaviorSubject<string> = new BehaviorSubject<string>("");
    public isLoginSuccess: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
    constructor(private httpClient: HttpClient) {
        
    }

    setToken(token: string) {
        this.authToken$.next(token);
        localStorage.setItem("token", token)
    }

    setDataVe(data: DatVeDto) {
        localStorage.setItem("maGhes", JSON.stringify(data.maGhes))
        localStorage.setItem("tongGia", JSON.stringify(data.tongGia))
        localStorage.setItem("soLuong", JSON.stringify(data.soLuong))
        localStorage.setItem("maXuatChieu", JSON.stringify(data.maXuatChieu))
        localStorage.setItem("maTaiKhoanDatVe", JSON.stringify(data.maTaiKhoan))
    }

    setIsLoginSuccess(isLoginSuccess: boolean) {
        this.isLoginSuccess.next(isLoginSuccess);
    }

    setInfo(info: any) {
        localStorage.setItem("maTaiKhoan",JSON.stringify(info.maTaiKhoan))
        localStorage.setItem("email",JSON.stringify(info.email))
    }

}