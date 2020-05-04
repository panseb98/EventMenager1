import { Component, OnInit } from '@angular/core';
import { NotyficationtoList } from '../Models/notification';
import { InvitationService } from 'src/app/services/invitation.service';
import { AuthService } from 'src/app/services/auth.service';
import { Alert } from 'src/app/Helpers/Models/Alert';
import { MatSnackBar } from '@angular/material/snack-bar';
import { EventService } from 'src/app/services/event.service';
import { ReturnModel } from 'src/app/Helpers/Models/ReturnModel';


export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}
 
@Component({
  selector: 'app-notification-list',
  templateUrl: './notification-list.component.html',
  styleUrls: ['./notification-list.component.css']
})
export class NotificationListComponent implements OnInit {

  displayedColumns: string[] = ['userSender', 'name', 'eventName',  'accept'];
  dataSource : Array<NotyficationtoList>;
  alertHelp : Alert;
  constructor(private _inviService : InvitationService, private auth : AuthService,  private _snackBar: MatSnackBar, private event : EventService) {
    this.alertHelp = Alert.getInstance(_snackBar);
   }

  ngOnInit(): void {
      this._inviService.getInvitations(parseInt(this.auth.decodeToken.nameid, 10)).subscribe(res => {
        this.dataSource = res;
        console.log(res);
      });
  }
  setNot(id : number){
      this.event.addParticipant({EventId: id, UserId: +this.auth.decodeToken.nameid}).subscribe(res => {
        this.alertHelp.openTopAlert(res as ReturnModel);
      })
  }

}
