import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {AdminProductsService} from "./admin-products.service";
import {MatSort} from "@angular/material/sort";
import {MatPaginator, PageEvent} from "@angular/material/paginator";
import {map} from "rxjs/operators";
import {MatTableDataSource} from "@angular/material/table";
import {Product} from "../../shared/data/Client.Api";

@Component({
  selector: 'app-dashboard-products',
  templateUrl: './dashboard-products.component.html',
  styleUrls: ['./dashboard-products.component.scss']
})
export class DashboardProductsComponent implements OnInit, AfterViewInit {
  view = 'list';
  displayedColumns: string[] = ['id', 'name', 'shortDescription', 'color', 'price'];
  //TODO: FixPagination
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort
  public dataSource!: MatTableDataSource<Product>;

  pageIndex!: number;
  pageSize: number | undefined;
  // pageEvent!: PageEvent;

  public counter: number | undefined;
  pageEvent!: PageEvent;

  constructor(public service: AdminProductsService) {
  }

  ngOnInit(): void {
    this.service.getProducts(1, 10)
        .pipe(
            map((data) => {
              this.dataSource = new MatTableDataSource(data.data);
              this.pageSize = data.pageSize;
              this.pageIndex = data.pageNumber as number;
              console.log(this.pageIndex)

            })
        )
        .subscribe();
    this.service.counter()
        .pipe(
            map((data) => {
              this.counter = data.counter;
              console.log(this.counter);
            })
        )
        .subscribe();
    // console.log(this.dataSource)
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator as MatPaginator;
    this.dataSource.sort = this.sort as MatSort;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase()
  }

  onPaginationChange($event: PageEvent) {
    //TODO!! FIX THIS
    // if (this.pageIndex)
    this.pageIndex += 1
    let page = this.pageIndex;
    // let page = $event.pageIndex + 1;
    let size = $event.pageSize;
    console.log($event.pageIndex)
    this.service.getProducts(page, size)
        .pipe(
            map((data) => {
              this.dataSource = new MatTableDataSource(data.data);
              this.pageSize = data.pageSize;
              this.pageIndex = data.pageNumber as number;
              console.log(data)
            })
        )
        .subscribe()
  }
}
