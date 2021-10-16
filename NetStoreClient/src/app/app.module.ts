import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppRoutingModule} from './app-routing.module';
import {API_BASE_URL, AppComponent} from './app.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {NgxSkeletonLoaderModule} from "ngx-skeleton-loader";
import {MatCardModule} from "@angular/material/card";
import {MatGridListModule} from "@angular/material/grid-list";
import {MatSidenavModule} from "@angular/material/sidenav";
import {MatIconModule} from "@angular/material/icon";
import {MatInputModule} from "@angular/material/input";
import {MatButtonModule} from "@angular/material/button";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {HttpClientModule} from "@angular/common/http";
import {SharedModule} from "./shared/shared.module";
import {JwtModule} from "@auth0/angular-jwt";
import {SharedFunctions} from "./shared/data/shared-functions";

export const MaterialModules = [
  MatCardModule,
  MatGridListModule,
  MatSidenavModule,
  MatIconModule,
  MatInputModule,
  MatButtonModule,
];

export const common = [
  FormsModule,
  ReactiveFormsModule,
  HttpClientModule
];

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    SharedModule,
    NgxSkeletonLoaderModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: SharedFunctions.GetToken,
        allowedDomains: ["https://localhost:5001"],
        disallowedRoutes: [],
      }
    })
  ],
  providers: [
    {
      provide: API_BASE_URL,
      useValue: "https://localhost:5001"
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
