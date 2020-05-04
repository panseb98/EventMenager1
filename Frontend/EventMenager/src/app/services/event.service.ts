import { Injectable } from '@angular/core';
import { EventModel } from '../Events/Models/Event';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SimpleEvent } from '../Events/Models/SimpleEvent';
import { AddParticipant } from '../Events/Models/AddParticipant';
import { EventToList } from '../Events/Models/EventToList';
import { EventVM } from '../Events/Models/EventViewModel';
import { ReceiptItem } from '../Events/Models/ReceiptItem';

@Injectable({
  providedIn: 'root'
})
export class EventService {

  constructor(private http : HttpClient) { 

  }
  register(event : EventModel){
    return this.http.post('https://localhost:44307/api/event/addevent', event);

  }
  getSimpleEvents(userId: string, userToId : string) : Observable<Array<SimpleEvent>> {
    let params = new HttpParams();
    params = params.append('userId', userId.toString());
    params = params.append('userToId', userToId.toString());
    return this.http.get<Array<SimpleEvent>>('https://localhost:44307/api/event/getsimpleevents', {params: params});
  }
  getEvent(eventId : number, userId : number){
    let params = new HttpParams();
    params = params.append('eventId', eventId.toString());
    params = params.append('userId', userId.toString());

    return this.http.get<EventVM>('https://localhost:44307/api/event/getevent', {params: params});
  }
  addParticipant(participant : AddParticipant){
    console.log(participant);
    return this.http.post('https://localhost:44307/api/event/addparticipant', participant);
  }
  getEvents(userId : number){
    let params = new HttpParams();
    params = params.append('userId', userId.toString());
    return this.http.get<Array<EventToList>>('https://localhost:44307/api/event/geteventsforuser',{params: params});
  }
  addReceiptItem(item : ReceiptItem){
    return this.http.post('https://localhost:44307/api/event/addreceiptitem', item);
  }
  getReceiptItems(participant : number){
    let params = new HttpParams();
    params = params.append('participant', participant.toString());
    return this.http.get<Array<ReceiptItem>>('https://localhost:44307/api/event/getreceiptitems', {params: params});
  }
  removeItem(receiptItem : number){
    console.log(receiptItem);
    return this.http.post('https://localhost:44307/api/event/removeReceiptItem', {id: receiptItem});
  }
}
