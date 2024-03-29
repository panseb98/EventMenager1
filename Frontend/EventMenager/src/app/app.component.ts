import { Component, OnInit } from '@angular/core';
import { AuthService } from './services/auth.service';
import {JwtHelperService} from '@auth0/angular-jwt';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  user : any;
  title = 'EventMenager';
  jwtHelper = new JwtHelperService();

  constructor(public auth : AuthService) {

  }
  ngOnInit(){
    const token = localStorage.getItem('token');
    if(token){
        this.auth.decodeToken = this.jwtHelper.decodeToken(token);
    }
  }
}
