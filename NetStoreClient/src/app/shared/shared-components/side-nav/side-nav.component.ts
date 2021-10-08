import {Component, OnInit} from '@angular/core';
import {Menu, menuList} from '../../data/menus';

@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.scss']
})
export class SideNavComponent implements OnInit {

  navList: Menu[] = [];

  constructor() {
  }

  ngOnInit(): void {
    this.navList = menuList;
  }


}
