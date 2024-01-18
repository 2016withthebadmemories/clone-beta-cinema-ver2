import { Component } from '@angular/core';
import { scrollToTop } from 'helper';

@Component({
  selector: 'app-rap',
  templateUrl: './rap.component.html',
  styleUrls: ['./rap.component.css']
})
export class RapComponent {
  ngOnInit() { 
    scrollToTop();
  }
}
