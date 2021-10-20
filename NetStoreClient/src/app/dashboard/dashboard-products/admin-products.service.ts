import {Injectable} from '@angular/core';
import {ProductPagedResponce, StoreClientApi} from "../../shared/data/Client.Api";
import {catchError, finalize, map} from "rxjs/operators";
import {throwError} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class AdminProductsService {
  // public dataSource!: MatTableDataSource<Product>;
  public isLoaded!: boolean;

  constructor(
      private client: StoreClientApi
  ) {
  }

  public getProducts(pageNumber?: number, pageSize?: number, title?: string) {
    this.isLoaded = false;
    return this.client
        .getProducts(pageNumber, pageSize, title)
        .pipe(
            map((data: ProductPagedResponce) => data),
            catchError((error: any) => throwError(error)),
            finalize(() => {
              this.isLoaded = true
            }))


  }

  public counter() {
    this.isLoaded = false;
    return this.client
        .countProducts()
        .pipe(
            map((data) => data),
            finalize(() => {
              this.isLoaded = true
            })
        )
  }
}
