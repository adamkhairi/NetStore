import {Injectable} from '@angular/core';
import {finalize} from "rxjs/operators";
import {ProductListResponce, StoreClientApi} from "../shared/data/Client.Api";


@Injectable({
  providedIn: 'root'
})
export class HomeService {
  public topProductsList!: ProductListResponce;
  public isLoaded!: boolean;

  constructor(
    private client: StoreClientApi,
  ) {
  }

  public getTopProducts() {
    this.isLoaded = false;
    this.client
      .getTopProducts()
      .pipe(
        finalize(() => {

          this.isLoaded = true;
        })
      )
      .subscribe(data => {
        this.topProductsList = data;
      });
  }

  init() {
    // this.client.getTopProducts().subscribe((data) => {
    //   // @ts-ignore
    //   this.topProducts = data;
    // });
  }
}
