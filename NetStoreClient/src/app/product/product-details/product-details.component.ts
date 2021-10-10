import {Component, OnInit} from '@angular/core';
import {DetailService} from "./detail.service";
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {

  constructor(public service: DetailService, private ar: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.ar.params.subscribe((params) => {
      this.service.productId = params['id'];
      this.service.getProduct();
    });
  }

}
