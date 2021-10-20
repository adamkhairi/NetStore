import {BreakpointObserver} from '@angular/cdk/layout';
import {Component, EventEmitter, HostListener, Input, OnInit, Output} from '@angular/core';
import {Menu, menuList as staticMenuList} from '../../data/menus';
import {SharedFunctions} from "../../data/shared-functions";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  @Input() topFixed!: boolean;
  @Output() toggleSidenav = new EventEmitter();
  isScrolled!: boolean;
  menuList: Menu[] = [];
  isLessThenLargeDevice!: boolean;
  @Output() public isAuthenticated!: boolean;
  @Output() User: any;
  @Output() isAdmin!: boolean;

  constructor(private breakpointObserver: BreakpointObserver) {
    this.isAuthenticated = SharedFunctions.isUserAuthenticated()
  }

  ngOnInit(): void {
    this.menuList = staticMenuList;
    this.breakpointObserver.observe(['(max-width: 1199px)']).subscribe(({matches}) => {
      this.isLessThenLargeDevice = matches;
    });
    if (this.isAuthenticated) {
      this.User = SharedFunctions.getDataFromLocalStorage();
      this.isAdmin = this.User.roles.toLowerCase().includes('admin');
      console.log(this.User);
    }
  }

  @HostListener('window:scroll', ['$event'])
  checkScroll() {
    this.isScrolled = window.pageYOffset > 15;
  }

  logOut() {
    SharedFunctions.LogOut();
  }
}
