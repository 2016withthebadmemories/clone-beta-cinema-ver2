import { environment } from './../environments/environment';
import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http'

@Injectable({
    providedIn:'root'
})
export class MomoService {
    constructor(private httpClient: HttpClient) {
        
    }

    thanhToan(data: thanhToanDto) {
       return this.httpClient.post(environment.baseApiUrl + "Momo", data);
    }

    thanhToanPaypal(data: any) {
        console.log("🚀 ~ MomoService ~ thanhToanPaypal ~ data:", data);
        return this.httpClient.post(environment.baseApiUrl + "Momo/Paypal", data);
     }
}

export interface thanhToanDto{
    fullName: string;
    orderInfo: string;
    amount: number;
}