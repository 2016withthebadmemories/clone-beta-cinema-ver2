import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { DateRangeFormService } from 'src/services/dateRangeForm.service';
import { PostService } from 'src/services/post.service';
import { RapDto, RapService } from 'src/services/rap.service';

@Component({
  selector: 'app-su-kien-gia',
  templateUrl: './su-kien-gia.component.html',
  styleUrls: ['./su-kien-gia.component.css']
})
export class SuKienGiaComponent {
  public listMaRap: number[] = [];
  raps: RapDto[] = [];
  gia: number = 0;
  public daysAndPrices = [
    { Ten: 'Thứ 2, 4, 5, 6 (45k)', giaVe: 45000 },
    { Ten: 'Thứ 3 - Happy day (40k)', giaVe: 40000 },
    { Ten: 'Thứ 7 (60k)', giaVe: 65000 },
    { Ten: 'Chủ Nhật (65k)', giaVe: 65000 },
    { Ten: 'Ngày lễ (80k)', giaVe: 80000 },
  ];
  constructor(
    public matDialogRef: MatDialogRef<SuKienGiaComponent>,
    private postService: PostService,
    @Inject(MAT_DIALOG_DATA) public data: SuKienGiaDialogData,
    private rapService: RapService,
    public dateRangeFormService: DateRangeFormService,
  ) { }
  ngOnInit() { 
    this.getAllRap();
  }

  capNhatGia() { 
    this.postService.capNhatGia({
      maRap: this.listMaRap,
      gia: this.gia
    }).subscribe(rs => {
      this.matDialogRef.close();
    })
  }
  getAllRap() {
    this.rapService.getAllRap().subscribe((rs) => {
      this.raps = rs;
    });
  }
  close() {
    this.matDialogRef.close();
  }
}
export interface SuKienGiaDialogData {
  rap: RapDto;
}

