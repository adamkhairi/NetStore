import {Injectable} from '@angular/core';
import {StoreClientApi} from "../../shared/data/netStoreClient";

@Injectable()
export class ProductsService {
  private _baseUrl = 'https://localhost:5001'
  public topProducts: any;

  constructor(private client: StoreClientApi) {


  }

  init() {
    this.client.getTopProducts().subscribe((data) => {

      this.topProducts = data;
    });
  }
}
