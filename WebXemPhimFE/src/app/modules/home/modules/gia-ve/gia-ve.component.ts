import { Component } from '@angular/core';
import { scrollToTop } from 'helper';

@Component({
  selector: 'app-gia-ve',
  templateUrl: './gia-ve.component.html',
  styleUrls: ['./gia-ve.component.css']
})
export class GiaVeComponent {

  ngOnInit() { 
    scrollToTop();
  }
}
