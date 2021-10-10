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
    CommonModule,
    RouterModule,
    MatListModule,
    MatSidenavModule,
    MatIconModule,
    MatButtonModule,
    MatCardModule,
    MatProgressSpinnerModule,
    MatSnackBarModule,
    HttpClientModule
  ],
  exports: [
    HttpClientModule,
    CardProductComponent,


  ]
})
export class SharedModule {
}
