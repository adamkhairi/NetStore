import {Injectable} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {ResponceProductDTO, StoreClientApi} from "../../shared/data/Client.Api";

@Injectable({
  providedIn: 'root'
})
export class DetailService {

  public productId!: string;
  public product!: ResponceProductDTO;

  constructor(private ar: ActivatedRoute, private client: StoreClientApi) {
  }

  public getProduct() {
    this.client.getProduct(this.productId)
      .pipe()
      .subscribe(data => {
        this.product = data;
      });
  }

}
