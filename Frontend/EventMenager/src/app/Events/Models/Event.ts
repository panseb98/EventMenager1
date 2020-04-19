import { UserToEvent } from './User';

export class EventModel{
    eventName: string;
    eventLocation : string;
    eventDate : Date;
    eventDescription : string;
    eventTypeId : number;
    eventUserId : number;
}