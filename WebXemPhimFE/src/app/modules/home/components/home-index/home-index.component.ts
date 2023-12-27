import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
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
  @Input() selectedRaps: string = '';

  constructor(
    private bannerService: BannerService,
    private activatedRoute: ActivatedRoute,
    private postService: PostService,
  ) { }

  ngOnInit() {
    this.activatedRoute.queryParams.subscribe((queryParams) => {
      console.log("🚀 ~ file: home-index.component.ts:30 ~ HomeIndexComponent ~ this.activatedRoute.queryParams.subscribe ~ queryParams:", queryParams);
      this.selectedRaps = queryParams['rap'];
      if (this.selectedRaps) {
        this.getPhimByRap();
      }
      this.getAllBanner();
    });
    this.getAllPost()
    this.getAllBanner();
  }

  getAllBanner() {
    this.bannerService.getAllBanner().subscribe(rs => {
      this.banners = rs;
    });
  }

  getPhimByRap() {
    console.log("Selected Raps:", this.selectedRaps);
    this.postService.getPhimByRap(this.selectedRaps).subscribe(rs => {
      this.phims = rs;
    });
  }

  getAllPost() {
    this.postService.getAllPost().subscribe(rs => {
      this.phims = rs;
    });
  }
}
