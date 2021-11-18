import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {LayoutsComponent} from './shared-components/layouts/layouts.component';
import {SideNavComponent} from './shared-components/side-nav/side-nav.component';
import {RouterModule} from "@angular/router";
import {MatListModule} from "@angular/material/list";
import {MatSidenavModule} from "@angular/material/sidenav";
import {HeaderComponent} from "./shared-components/header/header.component";
import {MatIconModule} from "@angular/material/icon";
import {MatButtonModule} from "@angular/material/button";
import {FooterComponent} from "./shared-components/footer/footer.component";
import {FeatureComponent} from "./shared-components/feature/feature.component";
import {MatCardModule} from "@angular/material/card";
import {LoaderComponent} from "./shared-components/loader/loader.component";
import {MatProgressSpinnerModule} from "@angular/material/progress-spinner";
import {MatSnackBarModule} from "@angular/material/snack-bar";
import {HttpClientModule} from "@angular/common/http";
import {CardProductComponent} from './shared-components/card-product/card-product.component';
import {MatMenuModule} from "@angular/material/menu";
import {MatSortModule} from "@angular/material/sort";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatInputModule} from "@angular/material/input";
import {MatTableModule} from "@angular/material/table";
import {MatPaginatorModule} from "@angular/material/paginator";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {MatSelectModule} from "@angular/material/select";


@NgModule({
  declarations: [
    LayoutsComponent,
    HeaderComponent,
    SideNavComponent,
    FooterComponent,
    FeatureComponent,
    LoaderComponent,
    CardProductComponent,


  ],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    RouterModule,
    MatListModule,
    MatSidenavModule,
    MatIconModule,
    MatButtonModule,
    MatCardModule,
    MatProgressSpinnerModule,
    MatSnackBarModule,
    MatMenuModule,
    MatPaginatorModule,
    MatTableModule,
    MatSortModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    HttpClientModule
  ],
  exports: [
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    CommonModule,
    RouterModule,
    MatListModule,
    MatSidenavModule,
    MatIconModule,
    MatButtonModule,
    MatCardModule,
    MatProgressSpinnerModule,
    MatSnackBarModule,
    MatMenuModule,
    MatSelectModule,
    MatTableModule,
    MatSortModule,
    MatFormFieldModule,
    MatInputModule,
    MatPaginatorModule,

    LayoutsComponent,
    HeaderComponent,
    SideNavComponent,
    FooterComponent,
    FeatureComponent,
    LoaderComponent,
    CardProductComponent,

  ]
})
export class SharedModule {
}
