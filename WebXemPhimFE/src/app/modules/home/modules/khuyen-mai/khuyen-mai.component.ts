import { Component } from '@angular/core';
import { scrollToTop } from 'helper';

@Component({
  selector: 'app-khuyen-mai',
  templateUrl: './khuyen-mai.component.html',
  styleUrls: ['./khuyen-mai.component.css']
})
export class KhuyenMaiComponent {
  ngOnInit() { 
    scrollToTop();
  }
}
