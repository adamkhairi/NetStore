import {Component, Input, OnInit} from '@angular/core';

@Component({
  selector: 'app-loader',
  templateUrl: './loader.component.html',
  styleUrls: ['./loader.component.scss']
})
export class LoaderComponent implements OnInit {
  @Input() center!: boolean;
  show: boolean = true;

  constructor() {
  }

  ngOnInit(): void {
    setTimeout(() => {
      this.show = false;
    }, 2500);
  }
}
