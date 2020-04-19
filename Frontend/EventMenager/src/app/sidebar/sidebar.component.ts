import { Component, Output, EventEmitter, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-sidebar',
    templateUrl: './sidebar.component.html',
    styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
    constructor(public auth : AuthService, private router : Router) {

    }

    ngOnInit() {

    }

    logout(){
        localStorage.removeItem('token');
        this.auth.decodeToken = null;
        this.router.navigate(['login']);


    }

}
