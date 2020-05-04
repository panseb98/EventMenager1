import { Injectable, ResolvedReflectiveFactory } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Register } from '../authorization/Models/register';
import { Login } from '../authorization/Models/login';
import {JwtHelperService} from '@auth0/angular-jwt';
import { LoggedUser } from '../authorization/Models/loggedUser';
import { Router } from '@angular/router';
import { UserToList } from '../authorization/Models/UserToList';
import { Observable } from 'rxjs';
import { UserProfile } from '../authorization/Models/UserProfile';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = 'http://localhost:51101/api/values';
  jwtHelper = new JwtHelperService();
  decodeToken : any;
  isLogged : boolean;
  
  constructor(private http : HttpClient,private router : Router) { }
  
  register(register : Register){
    let s = this.http.post('https://localhost:44307/api/auth/register', register);
    s.subscribe(res => console.log(res));
    
  }

  loginn(login : Login) {
    return this.http.post('https://localhost:44307/api/auth/login', login).subscribe(res => {
        
        if(res){
          localStorage.setItem('token', JSON.stringify(res));
          const token = localStorage.getItem('token');
          this.decodeToken = this.jwtHelper.decodeToken(token);
          this.router.navigate(['']);
        }
  });
  } 

  getFriends(userId : number){

  }
  getProfileData(userId : number) : Observable<UserProfile>{
    let params = new HttpParams();
    params = params.append('userId', userId.toString());
    return this.http.get<UserProfile>('https://localhost:44307/api/auth/getuser', {params: params});
  }
  getAllUsers() : Observable<Array<UserToList>>{
    return this.http.get<Array<UserToList>>('https://localhost:44307/api/auth/getusers');
  }


}
