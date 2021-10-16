import {Component, OnInit} from '@angular/core';
import {productsDB} from "../../shared/data/products";

// import { productsDB } from 'src/app/shared/data/products';

@Component({
  selector: 'app-dashboard-saved-item',
  templateUrl: './dashboard-saved-item.component.html',
  styleUrls: ['./dashboard-saved-item.component.scss']
})
export class DashboardSavedItemComponent implements OnInit {
  view = 'list';

  public products !: any[];

  constructor() {
  }

  ngOnInit(): void {
    this.products = productsDB.Product;
  }
}
