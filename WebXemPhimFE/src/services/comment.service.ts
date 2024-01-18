import { BinhLuanDto, GetBinhLuanDto } from './../app/modules/admin/modules/comment/list-comment/list-comment.component';
import { PhimDto } from './../app/modules/home/modules/post/post.component';
import { environment } from './../environments/environment';
import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http'

@Injectable({
    providedIn:'root'
})
export class CommentService {
    constructor(private httpClient: HttpClient) {
        
    }

    getAllComment() {
       return this.httpClient.get<GetBinhLuanDto[]>(environment.baseApiUrl + "BinhLuan");
    }

    getCommentById(id: number) {
        return this.httpClient.get<BinhLuanDto>(environment.baseApiUrl + `BinhLuan/${id}`)
    }
    createComment(data: BinhLuanDto) {
        return this.httpClient.post<BinhLuanDto>(environment.baseApiUrl + "BinhLuan", data)
    }
    delete(id: number) {
        return this.httpClient.delete(environment.baseApiUrl + `BinhLuan?id=${id}`);
    }
}