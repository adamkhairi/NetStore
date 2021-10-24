import {Injectable} from '@angular/core';
import {StoreClientApi} from "../data/Client.Api";
import {NotificationService} from "./notification.service";
import {Router} from "@angular/router";
import {catchError, map} from "rxjs/operators";
import {throwError} from "rxjs";
import {FormBuilder} from "@angular/forms";

@Injectable({
  providedIn: 'root'
})

export class ProductsService {


  constructor(
      private client: StoreClientApi,
      public notification: NotificationService,
      public router: Router,
      public fb: FormBuilder
  ) {
  }

  public searchForm = this.fb.group({
    searchInput: [null, []]
  })


  public getTopProducts() {
    return this.client
        .getTopProducts()
        .pipe(
            map((data) => data),
            catchError((error: any) => throwError(error)),
        )
  }


  public getProducts(pageNumber?: number, pageSize?: number, title?: string,) {
    return this.client
        .getProducts(pageNumber, pageSize, title)
        .pipe(
            map((data) => data),
            catchError((error: any) => throwError(error))
        );
  }


  public getProduct(productId: string) {
    return this.client.getProduct(productId)
        .pipe(
            map((data) => data),
            catchError((error: any) => throwError(error))
        );
  }
}



