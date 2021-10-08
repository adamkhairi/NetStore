import {Component, OnInit} from '@angular/core';
import {ProductsService} from "./products.service";
import {productsDB} from "../../shared/data/products";

// import { productsDB } from '../../shared/data/products';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit {
  isLoaded!: boolean;
  advanceSearchExpanded: boolean = false;
  products: any[] = [];

  constructor() {
  }

  ngOnInit(): void {
    setTimeout(() => {
      this.products = productsDB.Product;
      // this.service.init();
      this.isLoaded = true
    }, 8000);
    // this.products = this.service.topProducts;
  }
}
