import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DatVeService } from 'src/services/datVe.service';

@Component({
  selector: 'app-thong-ke',
  templateUrl: './thong-ke.component.html',
  styleUrls: ['./thong-ke.component.css']
})
export class ThongKeComponent {
  chartData: any[] = [];
  chartDataRap: any[] = [];
  cinemaSummaryList: any[] = [];
  cinemaSummaryListChart: any[] = [];
  chartLabels: string[] = [];
  chartLabelsRap: string[] = [];
  moviesData: any[] = [];
  moviesDataFoChart: any[] = [];
  chartOptions: any = {
    responsive: true,
    scales: {
      xAxes: [{
        // options...
      }],
      yAxes: [{
        ticks: {
          min: 0,
          // other options...
        }
        // other options...
      }]
    },
    // Các tùy chọn khác của biểu đồ
  };
  chartOptionsRap: any = {
    responsive: true,
  }
  chartType = 'bar'; // Loại biểu đồ (bar, line, pie, ...)
  chartTypeRap = 'pie'; // Loại biểu đồ (bar, line, pie, ...)
  currentDate: string;
  listRap: any[] = [];
  listRapChart: any[] = [];
  totalTongTien: string = '0';
  constructor(private datVeService: DatVeService, private dialog: MatDialog) {}
  ngOnInit() {
    this.loadChart();
  }

  loadChart() {
    this.currentDate = this.getCurrentDateString();
    this.GetChart(this.currentDate);
    this.getListChartForRap(this.currentDate);
  }


  getListChartForRap(date: string): void {
    this.datVeService.GetChart(date).subscribe((data) => {
      this.moviesData = data as Object[];
  
      this.cinemaSummaryList = this.moviesData.reduce((acc, currentMovie) => {
        const existingCinema = acc && acc.find(cinema => cinema.rap && cinema.rap.maRap === currentMovie.rap.maRap);
  
        if (existingCinema) {
          existingCinema.tongTien += currentMovie.tongTien;
        } else {
          acc.push({
            rap: currentMovie.rap,
            tongTien: currentMovie.tongTien
          });
        }
  
        return acc;
      }, []);
  
      // Lưu giá trị của acc vào this.listRap
      this.listRap = this.cinemaSummaryList;  
      this.chartLabelsRap = this.listRap.map(item => item.rap.tenRap);
      this.chartDataRap = [{
        data: this.listRap.map(item => item.tongTien),
        label: 'Tổng Tiền'
      }];
    });
  }
  
  GetChart(date: string) {
    this.datVeService.GetChart(date).subscribe((data) => {
      this.moviesDataFoChart = data as Object[];
      this.cinemaSummaryListChart = this.moviesDataFoChart.reduce((acc, currentMovie) => {
        const existingCinema = acc && acc.find(cinema => cinema.phim && cinema.phim.maPhim === currentMovie.phim.maPhim);
  
        if (existingCinema) {
          existingCinema.tongTien += currentMovie.tongTien;
        } else {
          acc.push({
            phim: currentMovie.phim,
            tongTien: currentMovie.tongTien
          });
        }
        
        return acc;
      }, []);
      this.listRapChart = this.cinemaSummaryListChart;  
      this.chartLabels = this.listRapChart.map(item => `${item.phim.tenPhim} - (${item.phim.rap.tenRap})`);
      this.totalTongTien = this.listRapChart.reduce((acc, item) => acc + item.tongTien, 0);
      this.chartData = [{
        data: this.listRapChart.map(item => item.tongTien),
        label: 'Tổng Tiền'
      }];
    });
  }

  loadChartWithDate(offset: number) {
    const newDate = this.calculateNewDate(offset);
    this.currentDate = newDate;
    this.GetChart(newDate);
    this.getListChartForRap(newDate);
  }

  private getCurrentDateString(): string {
    const currentDate = new Date();
    return currentDate.toLocaleDateString('en-CA', { year: 'numeric', month: '2-digit', day: '2-digit' }).replace(/\//g, '-');
  }

  private calculateNewDate(offset: number): string {
    const currentDate = new Date(this.currentDate);
    const newDate = new Date(currentDate);
  
    newDate.setDate(currentDate.getDate() + offset);
  
    const year = newDate.getFullYear();
    const month = (newDate.getMonth() + 1).toString().padStart(2, '0');
    const day = newDate.getDate().toString().padStart(2, '0');
  
    return `${year}-${month}-${day}`;
  }
  
}
