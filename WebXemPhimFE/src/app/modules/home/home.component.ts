import { RapDto } from './../../../services/rap.service';
import { TopicService } from 'src/services/topic.service';
import { PostService } from './../../../services/post.service';
import { Component } from '@angular/core';
import { topicDto } from '../admin/modules/topic/list-topic/list-topic.component';
import { PhimDto } from './modules/post/post.component';
import { CommentService } from 'src/services/comment.service';
import { BinhLuanDto } from '../admin/modules/comment/list-comment/list-comment.component';
import { Router } from '@angular/router';
import { RapService } from 'src/services/rap.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  public topic: topicDto[] = [];
  public post: PhimDto[] = [];
  public comment: BinhLuanDto[] = [];
  public raps: RapDto[] = [];
  public searchText = "";
  public selectedRap: string = "";
  public isDropdownOpen: boolean = false;
  public isShowBtnLgLo: boolean = true;
  constructor(
    private postService: PostService,
    private topicService: TopicService,
    private commentService: CommentService,
    private router: Router,
    private rapService: RapService
  ) { 
  }
  
  ngOnInit() {
    const token = localStorage.getItem("token");
    const email = localStorage.getItem("email");
    const maTaiKhoan = localStorage.getItem("maTaiKhoan");
    if (token) {
      this.isShowBtnLgLo = false;
    }
    console.log("🚀 ~ file: home.component.ts:41 ~ HomeComponent ~ ngOnInit ~ isShowBtnLgLo:", this.isShowBtnLgLo);
    this.getAllPost();
    this.getAllTopic();
    this.getAllRap();
  }
  getAllPost() {
    this.postService.getAllPost().subscribe(rs => {
      this.post = rs
    })
  }
  getAllTopic() {
    this.topicService.getAllTopic().subscribe((rs) => {
      this.topic = rs;
    });
  }
  getAllComment() {
    this.commentService.getAllComment().subscribe((rs) => {
      this.comment = rs;
    });
  }
  toggleDropdown(): void {
    this.isDropdownOpen = !this.isDropdownOpen;
  }

  onRapSelect(rap: string): void {
    this.selectedRap = rap;
    this.router.navigate(['/home'], {
      queryParams: {
        rap: this.selectedRap
      }
    });
    this.isDropdownOpen = false;
  }
  getCurrentDateTime() {
    const months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
    const days = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
  
    const now = new Date();
    const day = days[now.getDay()];
    const date = now.getDate();
    const month = months[now.getMonth()];
    const year = now.getFullYear();
  
    return `${day}, ${date} ${month} ${year}`;
  }

  search() {
    this.router.navigate(['/home','search'], {
      queryParams: {
        q: this.searchText
      }
    })
  }
  getAllRap() {
    this.rapService.getAllRap().subscribe((rs) => {
      this.raps = rs;
    });
  }

  logOut() {
    localStorage.clear();
    this.isShowBtnLgLo = true;
  }
  
}