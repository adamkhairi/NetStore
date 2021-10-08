import {Injectable} from '@angular/core';
import {StoreClientApi} from "../../shared/data/netStoreClient";

@Injectable({
  providedIn: 'root'
})

export class ProductsService {
  private _baseUrl = 'https://localhost:5001';
  public topProducts: any;

  constructor() {
  }

  // init() {
  //   this.client.getTopProducts().subscribe(data => {
  //     this.topProducts = data;
  //   });
  //
  // }
}



