import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {AdminProductsService} from "../../shared/services/admin-products.service";
import {MatSort} from "@angular/material/sort";
import {MatPaginator, PageEvent} from "@angular/material/paginator";
import {finalize, map} from "rxjs/operators";
import {MatTableDataSource} from "@angular/material/table";
import {Product} from "../../shared/data/Client.Api";
import {animate, state, style, transition, trigger} from "@angular/animations";

@Component({
  selector: 'app-dashboard-products',
  templateUrl: './dashboard-products.component.html',
  styleUrls: ['./dashboard-products.component.scss'],
  providers: [AdminProductsService],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class DashboardProductsComponent implements OnInit, AfterViewInit {
  view = 'list';
  displayedColumns: string[] = ['id', 'name', 'shortDescription', 'color', 'price'];
  //TODO: FixPagination
  @ViewChild(MatPaginator) paginator!: MatPaginator | null;
  @ViewChild(MatSort) sort!: MatSort
  public dataSource!: MatTableDataSource<Product>;

  pageIndex!: number;
  pageSize!: number;
  lastPageIndex!: number;
  public isLoaded!: boolean;
  public counter: number | undefined;
  pageEvent!: PageEvent;
  expandedElement!: Product | null;

  constructor(public service: AdminProductsService) {
  }

  ngOnInit(): void {
    this.isLoaded = false;

    this.service.counter()
        .pipe(
            map((data) => {
              this.counter = data.counter;
              console.log(this.counter);
            }),
            finalize(() => {
              this.isLoaded = true
            })
        )
        .subscribe();

    this.service.getProducts(1, 10)
        .pipe(
            map((data) => {
              this.dataSource = new MatTableDataSource<Product>(data.data);
              this.dataSource.paginator = this.paginator;
              this.dataSource.sort = this.sort as MatSort;
              this.pageSize = data.pageSize as number;
              this.pageIndex = data.pageNumber as number;
              console.log(this.pageIndex);

            }),
            finalize(() => {
              this.isLoaded = true
            })
        )
        .subscribe();

    // console.log(this.dataSource)
  }

  ngAfterViewInit() {

  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
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
              this.pageSize = data.pageSize as number;
              this.pageIndex = data.pageNumber as number;
              console.log(data)
            }),
            finalize(() => {
              this.isLoaded = true
            })
        )
        .subscribe();
  }
}
