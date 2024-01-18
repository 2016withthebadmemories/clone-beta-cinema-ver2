import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DatVeDto, DatVeService, ListVeDto } from 'src/services/datVe.service';
import { ChartDataSets, ChartOptions, ChartType } from 'chart.js';
import { Label } from 'ng2-charts';
import { XacNhanComponent } from '../xac-nhan/xac-nhan.component';

@Component({
  selector: 'app-list-ve',
  templateUrl: './list-ve.component.html',
  styleUrls: ['./list-ve.component.css']
})
export class ListVeComponent {
  public ve: ListVeDto[] = [];
  public listTenGhe: string[] = [];
  chartData: any[] = [];
  chartLabels: string[] = [];
  chartOptions: any = {
    responsive: true,
    // Các tùy chọn khác của biểu đồ
  };
  chartType = 'pie'; // Loại biểu đồ (bar, line, pie, ...)
  constructor(private datVeService: DatVeService, private dialog: MatDialog) {}
  ngOnInit() {
    this.GetAllVe();
  }
  GetAllVe() {
    this.datVeService.GetAllVe().subscribe((rs) => {
      this.ve = rs;
    });
  }

  deleteVe(id: number) {
    this.openDeleteConfirmationDialog(id);
  }
  
  openDeleteConfirmationDialog(id: number): void {
    const dialogRef = this.dialog.open(XacNhanComponent, {
      width: '300px', // You can adjust the width as needed
    });
  
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.datVeService.xoaVe(id).subscribe((rs) => {    
          this.GetAllVe();
        });
      }
    });
  }
}
