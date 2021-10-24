import {Component, OnInit} from '@angular/core';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.scss']
})
export class ContactComponent implements OnInit {
  public isLoaded!: boolean;

  constructor() {
  }

  ngOnInit(): void {
    setTimeout(() => {
      this.isLoaded = true;
    }, 1500);
  }

}
