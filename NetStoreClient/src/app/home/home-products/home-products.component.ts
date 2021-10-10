import {Component, OnInit} from '@angular/core';
import {HomeService} from "../home.service";
import {productsDB} from "../../shared/data/products";

// import { productsDB } from '../../shared/data/products';
@Component({
  selector: 'app-home-products',
  templateUrl: './home-products.component.html',
  styleUrls: ['./home-products.component.scss']
})
export class HomeProductsComponent implements OnInit {
  products: any[] = [];

  constructor(public service: HomeService) {

  }

  ngOnInit(): void {
    // setTimeout(() => {
    this.products = productsDB.Product;
    this.service.getTopProducts();
    // this.service.isLoaded = true;
    // }, 8000);
  }

}
