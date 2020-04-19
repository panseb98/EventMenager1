import { Injectable } from '@angular/core';
import { EventModel } from '../Events/Models/Event';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SimpleEvent } from '../Events/Models/SimpleEvent';

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
}
