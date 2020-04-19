import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AddInvitation } from '../Users/Models/AddInvitation';

@Injectable({
  providedIn: 'root'
})
export class InvitationService {

  constructor(private http : HttpClient) { 

  }
  addInvitation(invtitation : AddInvitation){
    return this.http.post('https://localhost:44307/api/invitation/addinvi', invtitation);

  }
}
