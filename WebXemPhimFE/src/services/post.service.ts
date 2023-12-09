import { PhimDto } from './../app/modules/home/modules/post/post.component';
import { environment } from './../environments/environment';
import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http'
import { BinhLuanDto } from 'src/app/modules/admin/modules/comment/list-comment/list-comment.component';

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
    getComment(postId: number) {
        return this.httpClient.get<BinhLuanDto[]>(environment.baseApiUrl + `Phim/postId=${postId}`)
    }
    getPostByText(text: string) {
        return this.httpClient.get<PhimDto[]>(environment.baseApiUrl + `Phim/search=${text}`)
    }
    createPost(data: PhimDto) {
        return this.httpClient.post(environment.baseApiUrl + "Phim", data)
    }
    editPost(data: PhimDto) {
        return this.httpClient.put(environment.baseApiUrl + "Phim", data)
    }
    delete(id: number) {
        return this.httpClient.delete(environment.baseApiUrl + `Phim?id=${id}`);
    }
}