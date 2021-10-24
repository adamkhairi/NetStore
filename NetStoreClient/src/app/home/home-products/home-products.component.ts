import {Component, OnInit} from '@angular/core';
import {ProductsService} from "../../shared/services/products.service";
import {map} from "rxjs/operators";
import {ProductPagedResponce} from "../../shared/data/Client.Api";

// import { productsDB } from '../../shared/data/products';
@Component({
  selector: 'app-home-products',
  templateUrl: './home-products.component.html',
  styleUrls: ['./home-products.component.scss']
})
export class HomeProductsComponent implements OnInit {
  topProducts!: ProductPagedResponce;
  public isLoaded!: boolean;

  constructor(public service: ProductsService) {

  }

  ngOnInit(): void {
    // setTimeout(() => {

    this.service.getTopProducts()
        .pipe(
            map((data) => {
              this.topProducts = data;
            })
        )
        .subscribe();
    // this.service.isLoaded = true;
    // }, 8000);
  }

}
