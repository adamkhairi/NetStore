import {Component, OnInit} from '@angular/core';
import {Menu, menuList} from '../../data/menus';
import {SharedFunctions} from "../../data/shared-functions";

@Component({
    selector: 'app-side-nav',
    templateUrl: './side-nav.component.html',
    styleUrls: ['./side-nav.component.scss']
})
export class SideNavComponent implements OnInit {

    navList: Menu[] = [];
    isAuthenticated!: boolean;
    isAdmin!: boolean;
    User!: any;

    constructor() {
        this.isAuthenticated = SharedFunctions.isUserAuthenticated()
    }

    ngOnInit(): void {
        this.navList = menuList;

        if (this.isAuthenticated) {
            this.User = SharedFunctions.getDataFromLocalStorage();
            this.isAdmin = this.User.roles.toLowerCase().includes('admin');
            console.log();
        }
    }


    logOut() {
        SharedFunctions.LogOut();
    }
}
