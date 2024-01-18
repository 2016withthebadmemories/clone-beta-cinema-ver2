import { environment } from './../environments/environment';
import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';

@Injectable({
    providedIn:'root'
})
export class GheService {
    constructor(private httpClient: HttpClient) {
        
    }
    getAllGheNotPagging() {
        return this.httpClient.get<GheDto[]>(environment.baseApiUrl + "Ghe");
     }
    getAllGhe(maPhong?: number): Observable<GheDto[]> {
        const url = maPhong ? `${environment.baseApiUrl}Ghe/maPhong=${maPhong}` : `${environment.baseApiUrl}Ghe`;
        return this.httpClient.get<GheDto[]>(url);
    }      
    getGheById(id: number) {
        return this.httpClient.get<GheDto>(environment.baseApiUrl + `Ghe/${id}`)
    }

    getGheByPhongId(data) {
        return this.httpClient.post<GheDto[]>(environment.baseApiUrl + "Ghe/getGhe", data)
    }
    createGhe(data: GheDto) {
        return this.httpClient.post(environment.baseApiUrl + "Ghe", data)
    }
    editGhe(data: GheDto) {
        return this.httpClient.put(environment.baseApiUrl + "Ghe", data)
    }
    delete(id: number) {
        return this.httpClient.delete(environment.baseApiUrl + `Ghe?id=${id}`);
    }
}

export interface GheDto{
    maGhe: number;
    tenGhe: string;
    tinhTrangGhe: boolean;
    trangThai: boolean;
    cot: number;
    hang: number;
    maPhong: string;
    tenPhong: string;
}