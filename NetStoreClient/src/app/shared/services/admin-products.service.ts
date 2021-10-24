import {Injectable} from '@angular/core';
import {ProductPagedResponce, StoreClientApi} from "../data/Client.Api";
import {catchError, map} from "rxjs/operators";
import {throwError} from "rxjs";

@Injectable()
export class AdminProductsService {
  // public dataSource!: MatTableDataSource<Product>;
  // public isLoaded!: boolean;

  constructor(
      private client: StoreClientApi
  ) {
  }

  public getProducts(pageNumber?: number, pageSize?: number, title?: string) {
    return this.client
        .getProducts(pageNumber, pageSize, title)
        .pipe(
            map((data: ProductPagedResponce) => data),
            catchError((error: any) => throwError(error))
        )
  }

  public counter() {
    return this.client
        .countProducts()
        .pipe(
            map((data) => data),
            catchError((error: any) => throwError(error))
        )
  }
}
