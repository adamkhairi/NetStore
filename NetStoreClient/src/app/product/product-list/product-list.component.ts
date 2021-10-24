import {Component, OnInit, ViewChild} from '@angular/core';
import {ProductsService} from "../../shared/services/products.service";
import {Product, ProductListResponce} from "../../shared/data/Client.Api";
import {finalize, map} from "rxjs/operators";
import {MatTableDataSource} from "@angular/material/table";
import {MatPaginator, PageEvent} from "@angular/material/paginator";

// import { productsDB } from '../../shared/data/products';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss'],

})
export class ProductListComponent implements OnInit {
  public isLoaded!: boolean;

  advanceSearchExpanded: boolean = false;
  public productsList!: ProductListResponce;
  public topProducts!: ProductListResponce;
  public dataSource!: MatTableDataSource<Product>;
  // products: any[] = [];
  @ViewChild(MatPaginator) paginator!: MatPaginator | null;

  constructor(public service: ProductsService) {
  }


  ngOnInit(): void {
    this.isLoaded = false;

    // setTimeout(() => {
    // this.products = productsDB.Product;
    this.service.getTopProducts()
        .pipe(
            map(data => this.topProducts = data)
        )
        .subscribe();

    this.service.getProducts()
        .pipe(
            map((data) => {
              this.productsList = data;
              this.dataSource = new MatTableDataSource<Product>(data.data);
              this.dataSource.paginator = this.paginator;
            }),
            finalize(() => {
              this.isLoaded = true;
            })
        )
        .subscribe();
    // }, 3000);

    this.service.searchForm.controls['searchInput'].valueChanges.subscribe((data: string) => {
      this.isLoaded = false;
      if (data != null)
        this.service.getProducts(1, undefined, data)
            .pipe(
                map((data) => {
                  this.productsList = data
                }),
                finalize(() => {
                  this.isLoaded = true;
                })
            )
            .subscribe();
    });
    // this.products = this.service.topProducts;
  }

  onPaginationChange($event: PageEvent) {
    this.isLoaded = false;
    let page = $event.pageIndex + 1;
    let size = $event.pageSize;
    console.log($event.pageIndex);
    this.service.getProducts(page, size)
        .pipe(
            map((data) => {
              this.dataSource = new MatTableDataSource(data.data);

              console.log(data)
            }),
            finalize(() => {
              this.isLoaded = true
            })
        )
        .subscribe();
  }
}
