import {Injectable} from '@angular/core';
import {Product, StoreClientApi} from "../../shared/data/Client.Api";
import {finalize} from "rxjs/operators";
import {MatTableDataSource} from "@angular/material/table";

@Injectable({
  providedIn: 'root'
})
export class AdminProductsService {
  public dataSource!: MatTableDataSource<Product>;
  public isLoaded: boolean = false;

  constructor(
      private client: StoreClientApi
  ) {
  }

  public getProducts(pageNumber?: number, pageSize?: number, title?: string) {
    return this.client
        .getProducts(pageNumber, pageSize, title)
        .pipe(finalize(() => {
          this.isLoaded = true
        }))
        .subscribe(data => {
          this.dataSource = new MatTableDataSource(data.data)
        })

  }
}
