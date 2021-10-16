import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {AdminProductsService} from "./admin-products.service";
import {MatSort} from "@angular/material/sort";
import {MatPaginator} from "@angular/material/paginator";

@Component({
  selector: 'app-dashboard-products',
  templateUrl: './dashboard-products.component.html',
  styleUrls: ['./dashboard-products.component.scss']
})
export class DashboardProductsComponent implements OnInit, AfterViewInit {
  view = 'list';
  displayedColumns: string[] = ['id', 'name', 'shortDescription', 'color', 'price'];
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(public service: AdminProductsService) {
    this.service.getProducts()
  }

  ngOnInit(): void {
    console.log(this.service.dataSource)
  }

  ngAfterViewInit() {
    this.service.dataSource.paginator = (this.paginator as MatPaginator);
    this.service.dataSource.sort = (this.sort as MatSort);
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.service.dataSource.filter = filterValue.trim().toLowerCase()
  }
}
