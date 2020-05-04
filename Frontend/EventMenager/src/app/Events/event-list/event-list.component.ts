import { Component, OnInit } from '@angular/core'
import { AuthService } from 'src/app/services/auth.service';
import { EventService } from 'src/app/services/event.service';
import { EventToList } from '../Models/EventToList';
import { Router } from '@angular/router';

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrls: ['./event-list.component.css']
})
export class EventListComponent implements OnInit {
  eventsList : Array<EventToList>;
  constructor(private _service : EventService, private _auth :  AuthService, private router : Router) { }
  displayedColumns: string[] = ['name', 'surname', 'city'];

  ngOnInit() {
    this._service.getEvents(+this._auth.decodeToken.nameid).subscribe( res => {this.eventsList = res as Array<EventToList>; console.log(res)});
  }
  eventClick(arg : EventToList){
    console.log(arg);
    this.router.navigate(['events/singleEvent', arg.eventId]);
  }

}
