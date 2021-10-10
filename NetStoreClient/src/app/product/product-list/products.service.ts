import {Injectable} from '@angular/core';
import {ProductListResponce, StoreClientApi} from "../../shared/data/Client.Api";
import {NotificationService} from "../../shared/notification.service";
import {Router} from "@angular/router";
import {finalize} from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})

export class ProductsService {
  public isLoaded!: boolean;
  public topProductsList!: ProductListResponce;
  public productsList!: ProductListResponce;

  constructor(
    private client: StoreClientApi,
    public notification: NotificationService,
    public router: Router,
    // public fb: FormBuilder,
  ) {
  }

  // init() {
  //   this.client.getTopProducts().subscribe(data => {
  //     this.topProducts = data;
  //   });
  //
  // }

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
    return this.topProductsList;
  }

  public getProducts(pageNumber?: number, pageSize?: number, title?: string) {
    this.isLoaded = false;
    this.client
      .getProducts(pageNumber, pageSize, title)
      .pipe(
        finalize(() => {

          this.isLoaded = true;
        })
      )
      .subscribe(data => {
        this.productsList = data;
      });
    return this.topProductsList;
  }
}



