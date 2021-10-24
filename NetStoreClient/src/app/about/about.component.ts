import {Component, OnInit} from '@angular/core';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.scss']
})
export class AboutComponent implements OnInit {
  public isLoaded!: boolean;

  constructor() {
  }

  ngOnInit(): void {
    setTimeout(() => {
      this.isLoaded = true;
    }, 1500);
  }

}
