import {BreakpointObserver} from '@angular/cdk/layout';
import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';
import {SharedFunctions} from "../../shared/data/shared-functions";

@Component({
  selector: 'app-dashboard-layout',
  templateUrl: './dashboard-layout.component.html',
  styleUrls: ['./dashboard-layout.component.scss']
})
export class DashboardLayoutComponent implements OnInit {
  public isLessThenLargeDevice!: boolean;
  public isAuthenticated!: boolean;

  constructor(private breakpointObserver: BreakpointObserver, private router: Router) {
    this.isAuthenticated = SharedFunctions.isUserAuthenticated()
  }

  ngOnInit(): void {
    this.breakpointObserver.observe(['(max-width: 1199px)']).subscribe(({matches}) => {
      this.isLessThenLargeDevice = matches;
    });
  }

  // isAuthenticated(): boolean {
  //   return SharedFunctions.isUserAuthenticated();
  // }

  async onLogout(): Promise<void> {
    await this.router.navigate(['auth/login']);
  }
}
