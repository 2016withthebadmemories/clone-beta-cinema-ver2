import { environment } from './../environments/environment';
import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http'

@Injectable({
    providedIn:'root'
})
export class RapService {
    constructor(private httpClient: HttpClient) {
        
    }

    getAllRap() {
       return this.httpClient.get<RapDto[]>(environment.baseApiUrl + "Rap");
    }
    createRap(data: RapDto) {
        return this.httpClient.post(environment.baseApiUrl + "Rap", data)
    }
    editRap(data: RapDto) {
        return this.httpClient.put(environment.baseApiUrl + "Rap", data)
    }
    delete(id: number) {
        return this.httpClient.delete(environment.baseApiUrl + `Rap?id=${id}`);
    }
}

export interface RapDto{
    maRap: number;
    tenRap: string;
    diaChi: string;
}