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


@NgModule({
  declarations: [
    LayoutsComponent,
    HeaderComponent,
    SideNavComponent,
    FooterComponent,
    FeatureComponent,
    LoaderComponent
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
  ],
  exports: []
})
export class SharedModule {
}
