import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { UserToList } from '../Models/UserToList';
import { Router } from '@angular/router';
import { UserPassService } from 'src/app/datapassServices/user-pass.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  userList : Array<UserToList>;
  displayedColumns: string[] = ['name', 'surname', 'city'];
  constructor(private auth : AuthService, private router: Router, private dataPass : UserPassService) { 
    
  }

  ngOnInit(): void {

    this.auth.getAllUsers().subscribe(res => {this.userList = res; console.log(this.userList);});
  }
  eventClick(arg : UserToList){
    console.log(arg);
    this.dataPass.setUserId(arg.userId);
    this.router.navigate(['user/view', arg.userId]);
  }

}
