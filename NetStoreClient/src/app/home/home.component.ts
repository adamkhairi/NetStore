import {Component, OnInit} from '@angular/core';
import {SharedFunctions} from "../shared/data/shared-functions";
import {ProductsService} from "../shared/services/products.service";


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  providers: []
})
export class HomeComponent implements OnInit {
  isAuthenticated!: boolean;
  public isLoaded!: boolean;

  particlesOptions = {
    particles: {
      color: {
        value: ['#ffffff', '#ffffff']
      },
      size: {
        value: 1
      },
      lineLinked: {
        enable: true,
        color: 'random'
      },
      move: {
        enable: true,
        speed: 1.5
      }
    }
  };

  constructor(public service: ProductsService) {
    this.isAuthenticated = SharedFunctions.isUserAuthenticated()
  }


  ngOnInit(): void {
    this.isLoaded = true;
  }
}
