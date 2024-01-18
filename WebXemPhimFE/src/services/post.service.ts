import { PhimDto, xuatChieuCreateForPhim, xuatChieuEditForPhim } from './../app/modules/home/modules/post/post.component';
import { environment } from './../environments/environment';
import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http'
import { BinhLuanDto } from 'src/app/modules/admin/modules/comment/list-comment/list-comment.component';
import { Observable } from 'rxjs';

@Injectable({
    providedIn:'root'
})
export class PostService {
    constructor(private httpClient: HttpClient) {
        
    }

    getAllPost() {
       return this.httpClient.get<PhimDto[]>(environment.baseApiUrl + "Phim");
    }

    getPostById(id: number) {
        return this.httpClient.get<PhimDto>(environment.baseApiUrl + `Phim/${id}`)
    }

    getPhimByRap(tenRap: string) {
        return this.httpClient.get<PhimDto[]>(environment.baseApiUrl + `Phim/tenRap=${tenRap}`)
    }

    getAllPhim() {
        return this.httpClient.get<PhimDto[]>(environment.baseApiUrl + `Phim/allPhim`)
    }

    getAllPhimAdmin(params?: {
        maRap?: number,
        ngayTao?: Date,
        trangThai?: boolean,
        tenPhim?: string,
        daodien?: string,
        hangPhim?: string,
        quocGia?: string
        }): Observable<PhimDto[]> {
        const queryString = params
            ? Object.keys(params)
                    .filter((key) => params[key] !== null && params[key] !== undefined)
                    .map((key) => `${key}=${encodeURIComponent(params[key])}`)
                    .join('&')
            : '';
    
        const apiUrl = environment.baseApiUrl + `Phim/allPhimAdmin` + (queryString ? `?${queryString}` : '');
    
        return this.httpClient.get<PhimDto[]>(apiUrl);
    }

    getComment(postId: number) {
        return this.httpClient.get<BinhLuanDto[]>(environment.baseApiUrl + `Phim/postId=${postId}`)
    }
    getPostByText(text: string) {
        return this.httpClient.get<PhimDto[]>(environment.baseApiUrl + `Phim/search=${text}`)
    }
    createPost(data: FormData) {
        return this.httpClient.post(environment.baseApiUrl + 'Phim', data);
    }
    createXuatChieuForPhim(data: xuatChieuCreateForPhim) {
        return this.httpClient.post(environment.baseApiUrl + 'Phim/xuatChieu', data);
    }

    editXuatChieuForPhim(data: xuatChieuEditForPhim) {
        return this.httpClient.put(environment.baseApiUrl + 'Phim/updateXuatChieu', data);
    }
    editPost(data: FormData) {
        return this.httpClient.put(environment.baseApiUrl + "Phim", data)
    }
    delete(id: number) {
        return this.httpClient.delete(environment.baseApiUrl + `Phim?id=${id}`);
    }

    capNhatGia(data: any) {
        return this.httpClient.put(environment.baseApiUrl + `Phim/UpdateGia?giaMoi=${data.gia}`, data.maRap);
    }
}