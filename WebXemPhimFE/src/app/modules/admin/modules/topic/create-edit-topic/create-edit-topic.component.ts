import { BannerDto, BannerService } from 'src/services/banner.service';
import { TopicService } from './../../../../../../services/topic.service';
import { topicDto } from './../list-topic/list-topic.component';
import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
@Component({
  selector: 'app-create-edit-topic',
  templateUrl: './create-edit-topic.component.html',
  styleUrls: ['./create-edit-topic.component.css'],
})
export class CreateEditTopicComponent {
  public banner: BannerDto = {} as BannerDto;
  public maBanner: any;
  selectedFile!: File;
  constructor(public matDialogRef: MatDialogRef<CreateEditTopicComponent>,
    private bannerService: BannerService,
    @Inject(MAT_DIALOG_DATA) public data: CreateEditTopicDialogData) {
  }
  ngOnInit() {
    if (this.data?.banner?.maBanner) {
      this.maBanner = this.data.banner.maBanner;
      this.banner = this.data.banner;
    }
  }
  
  onFileSelected(event: any) {
    this.selectedFile = event.target.files[0];
    }
  
  close() {
    this.matDialogRef.close();
  }

  create() {
    const formData = new FormData();
    formData.append('anh', this.selectedFile, this.selectedFile.name);
    if (this.banner.maBanner) {
      formData.append('maBanner', this.banner.maBanner.toString());
      this.bannerService.editBanner(formData).subscribe(rs => {
        this.close()
      })
    } else {
      this.bannerService.createBanner(formData).subscribe(rs => {
        this.close()
      })
    }
    
  }
}

export interface CreateEditTopicDialogData{
  banner: BannerDto
}