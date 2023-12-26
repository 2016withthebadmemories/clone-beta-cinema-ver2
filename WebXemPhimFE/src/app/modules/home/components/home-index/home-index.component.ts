import { Component, Input } from '@angular/core';
import { PostService } from 'src/services/post.service';
import { PhimDto } from '../../modules/post/post.component';
import { ActivatedRoute } from '@angular/router';
import { BannerDto, BannerService } from 'src/services/banner.service';

@Component({
  selector: 'app-home-index',
  templateUrl: './home-index.component.html',
  styleUrls: ['./home-index.component.css'],
})
export class HomeIndexComponent {
  public banners: BannerDto[] = [];
  public phims: PhimDto[] = [];

  constructor(
    private bannerService: BannerService,
    private activatedRoute: ActivatedRoute,
    private postService: PostService,
  ) { }
  ngOnInit() {
    this.getAllBanner();
    this.getAllPost();
  }
  getAllBanner() {
    this.activatedRoute.params.subscribe(s => {

      this.bannerService.getAllBanner().subscribe(rs => {
        this.banners = rs
      })
    })
  }

  getAllPost() {
    this.activatedRoute.params.subscribe(s => {

      this.postService.getAllPost().subscribe(rs => {
        this.phims = rs
      })
    })
  }
}
