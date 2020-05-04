import { UserToEvent } from './User';

export class EventDTO {
    id : number;
    eventName : string;
    eventLocation : string;
    eventDescription : string;
    eventType : EventTypeDTO;
    eventTypeId : number;
    eventCreation : Date;
    eventDate : Date;
    eventParticipants : Array<ParticipantDTO>;
    eventUserId : number;
    eventUser : UserToEvent;
}

export class EventTypeDTO{
    id: number;
    eventTypeName : string;
}
export class ParticipantDTO{

}