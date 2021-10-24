import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {ProductsService} from "../../shared/services/products.service";
import {map} from "rxjs/operators";
import {ResponceProductDTO} from "../../shared/data/Client.Api";

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  productId!: string;
  product: ResponceProductDTO | undefined;

  constructor(public service: ProductsService, private ar: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.ar.params.subscribe((params) => {
      this.productId = params['id'];
      this.service.getProduct(this.productId)
          .pipe(
              map((data) => {
                this.product = data
              })
          )
          .subscribe();
    });
  }

}
