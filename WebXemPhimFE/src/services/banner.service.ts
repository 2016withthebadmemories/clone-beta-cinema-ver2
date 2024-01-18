import { environment } from './../environments/environment';
import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http'

@Injectable({
    providedIn:'root'
})
export class BannerService {
    constructor(private httpClient: HttpClient) {
        
    }

    getAllBanner() {
       return this.httpClient.get<BannerDto[]>(environment.baseApiUrl + "Banner");
    }
    createBanner(data: FormData) {
        return this.httpClient.post(environment.baseApiUrl + "Banner", data)
    }

    editBanner(data: FormData) {
        return this.httpClient.put(environment.baseApiUrl + "Banner", data)
    }
    delete(id: number) {
        return this.httpClient.delete(environment.baseApiUrl + `Banner?id=${id}`);
    }
}

export interface BannerDto{
    maBanner: number;
    ten: string;
}