import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { AddInvitation } from '../Users/Models/AddInvitation';
import { NotyficationtoList } from '../dashboard/Models/notification';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InvitationService {

  constructor(private http : HttpClient) { 

  }
  addInvitation(invtitation : AddInvitation){
    return this.http.post('https://localhost:44307/api/invitation/addinvi', invtitation);

  }
  getInvitations(userId : number) : Observable<Array<NotyficationtoList>>{
    let params = new HttpParams();
    params = params.append('userId', userId.toString());
    return this.http.get<Array<NotyficationtoList>>('https://localhost:44307/api/invitation/getinvitations', {params: params});
  }
  
  acceptInvitation(invitationId : number){
    return this.http.post('https://localhost:44307/api/invitation/addinvi', invitationId);
  }
}
