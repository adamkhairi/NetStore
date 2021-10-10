import {Component, Input, OnInit} from '@angular/core';
import {Product} from "../../data/Client.Api";

@Component({
  selector: 'app-card-product',
  templateUrl: './card-product.component.html',
  styleUrls: ['./card-product.component.scss']
})
export class CardProductComponent implements OnInit {
  @Input() product!: Product;

  constructor() {
  }

  ngOnInit(): void {
  }

}
