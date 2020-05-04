import { UserToEvent } from './User';
import { UserToList } from 'src/app/authorization/Models/UserToList';
import { ReceiptItem } from './ReceiptItem';

export class EventVM {
    id : number;
    eventName : string;
    eventLocation : string;
    eventDescription : string;
    eventType : string;
    eventCreation : Date;
    eventDate : Date;
    eventParticipants : Array<ParticipantVM>;
    eventParticipant : number;
   // eventUserId : number;
    //eventUserCreator : UserToEvent;
}

export class ParticipantVM{
    id : number;
    user : UserToList;
    receiptItems : Array<ReceiptItemVM>
}
export class ReceiptItemVM{
    id : number;
    prodName : string;
    amount : number;
    price : number;
    participant : number;
}