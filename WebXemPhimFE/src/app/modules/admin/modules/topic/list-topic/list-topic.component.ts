import { TopicService } from './../../../../../../services/topic.service';
import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CreateEditTopicComponent } from '../create-edit-topic/create-edit-topic.component';
import { BannerDto, BannerService } from 'src/services/banner.service';
import { XacNhanComponent } from '../../xac-nhan/xac-nhan.component';

@Component({
  selector: 'app-list-topic',
  templateUrl: './list-topic.component.html',
  styleUrls: ['./list-topic.component.css'],
})
export class ListTopicComponent {
  public banner: BannerDto[] = [];
  constructor(private bannerService: BannerService, private dialog: MatDialog) {}

  ngOnInit() {
    this.getAllBanner();
  }
  getAllBanner() {
    this.bannerService.getAllBanner().subscribe((rs) => {
      this.banner = rs;
    });
  }
  create() {
    const dialogRef = this.dialog.open(CreateEditTopicComponent, {});
    dialogRef.afterClosed().subscribe((rs) => {
      this.getAllBanner();
    });
  }
  edit(item: BannerDto) {
    const dialogRef = this.dialog.open(CreateEditTopicComponent, {
      data: {
        banner: JSON.parse(JSON.stringify(item)),
      },
    });
    dialogRef.afterClosed().subscribe((rs) => {
      this.getAllBanner();
    });
  }

  deleteTopic(id: number) {
    this.openDeleteConfirmationDialog(id);
  }
  
  openDeleteConfirmationDialog(id: number): void {
    const dialogRef = this.dialog.open(XacNhanComponent, {
      width: '300px', // You can adjust the width as needed
    });
  
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.bannerService.delete(id).subscribe((rs) => {
          this.getAllBanner();
        });
      }
    });
  }
}
export interface topicDto {
  id?: number;
  name: string;
}
