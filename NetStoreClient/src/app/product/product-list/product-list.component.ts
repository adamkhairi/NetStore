import {Component, OnInit} from '@angular/core';
import {ProductsService} from "./products.service";

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

  constructor(public service: ProductsService) {
  }

  ngOnInit(): void {
    setTimeout(() => {
      this.service.init();
      this.isLoaded = true
    }, 8000);
    this.products = this.service.topProducts;
  }
}
