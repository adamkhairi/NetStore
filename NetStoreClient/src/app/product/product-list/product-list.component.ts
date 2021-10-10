import {Component, OnInit} from '@angular/core';
import {productsDB} from "../../shared/data/products";
import {ProductsService} from "./products.service";

// import { productsDB } from '../../shared/data/products';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss'],

})
export class ProductListComponent implements OnInit {

  advanceSearchExpanded: boolean = false;
  products: any[] = [];

  constructor(public service: ProductsService) {
  }

  ngOnInit(): void {
    setTimeout(() => {
      this.products = productsDB.Product;
      this.service.getTopProducts();
      this.service.getProducts();
    }, 3000);


    // this.products = this.service.topProducts;
  }
}
