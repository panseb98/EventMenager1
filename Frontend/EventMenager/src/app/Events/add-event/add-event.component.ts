import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, NgForm, FormBuilder } from '@angular/forms';
import { EventModel } from '../Models/Event';
import { EventType } from '../Models/EventType';
import { AuthService } from 'src/app/services/auth.service';
import { EventService } from 'src/app/services/event.service';

@Component({
  selector: 'app-add-event',
  templateUrl: './add-event.component.html',
  styleUrls: ['./add-event.component.css']
})
export class AddEventComponent implements OnInit {
  meme : EventModel
  public form = new FormGroup({
    eventName : new  FormControl(''), 
    eventLocation : new FormControl(''),
    eventDescription : new FormControl(''),
    eventTypeId : new FormControl(''),
    eventDate : new FormControl('')


  });
  public eventsType = new Array<EventType>();
  constructor(private auth : AuthService, private eventService : EventService) { 
    this.eventsType.push({eventId : 1, eventName: "Koncert"}, {eventId: 2, eventName: "Clubbing"}, {eventId: 3, eventName: "Domówka"}, {eventId: 4, eventName: "Spektakl"});
  }

  ngOnInit() {
  }
  submit(){
    this.meme = this.form.value as EventModel;
    this.meme.eventTypeId = +this.meme.eventTypeId;
    this.meme.eventUserId = parseInt(this.auth.decodeToken.nameid, 10);
    this.eventService.register(this.meme).subscribe(res => console.log(res));
    console.log(this.meme);
  }


}
