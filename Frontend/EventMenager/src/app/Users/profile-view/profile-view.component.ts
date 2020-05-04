import { Component, OnInit, Inject } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { UserPassService } from 'src/app/datapassServices/user-pass.service';
import { UserProfile } from 'src/app/authorization/Models/UserProfile';
import { Router, ActivatedRoute } from '@angular/router';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA, MatDialogModule } from '@angular/material/dialog';
import { EventService } from 'src/app/services/event.service';
import { SimpleEvent } from 'src/app/Events/Models/SimpleEvent';
import { InvitationService } from 'src/app/services/invitation.service';
import { AddInvitation } from '../Models/AddInvitation';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';
import { Alert } from 'src/app/Helpers/Models/Alert';
import { ReturnModel } from 'src/app/Helpers/Models/ReturnModel';

@Component({
  selector: 'app-profile-view',
  templateUrl: './profile-view.component.html',
  styleUrls: ['./profile-view.component.css']
})
export class ProfileViewComponent implements OnInit {
  userId : number;
  userIdLogged : number;
  newInvitation : AddInvitation;
  public simpleEvent : Array<SimpleEvent>
  userProfile : any;
  dataLoaded: boolean = false;
  alertHelp : Alert;
  constructor(private eventService : EventService, 
    private authService : AuthService, 
     private route : ActivatedRoute, 
     public dialog: MatDialog, 
     private inviService : InvitationService,
     private _snackBar: MatSnackBar) {
      this.alertHelp = Alert.getInstance(_snackBar);
    }

  ngOnInit(): void {
      this.userId = +this.route.snapshot.paramMap.get("user");
      this.userIdLogged = this.authService.decodeToken.nameid;
      this.authService.getProfileData(this.userId).subscribe(res =>{
        this.userProfile = res;
        this.dataLoaded = true;
        console.log(this.userProfile);
        console.log('meme');

      });
      this.eventService.getSimpleEvents(this.userIdLogged.toString(), this.userId.toString()).subscribe(res =>{ this.simpleEvent = res; console.log(this.simpleEvent);});
    
  }
  animal: string;
  name: string;

  openDialog(): void {

    const dialogRef = this.dialog.open(ProfileViewPopup, {
      width: '250px',
      data: {simpleEvent : this.simpleEvent, val : 'Dawaj event'}
    });

    dialogRef.afterClosed().subscribe(result => {
     if(typeof result != 'undefined'){
      let newInvitation =  {
        userIdSender : +this.userIdLogged,
        userIdRept : +this.userId,
        eventId : result,
        invitationType : 'EVENT_INVITATION'
      } as AddInvitation;
      console.log(newInvitation);
      this.inviService.addInvitation(newInvitation).subscribe(res => this.alertHelp.openTopAlert(res as ReturnModel));
    } 
     

    
    });
  }

}
export interface DialogData {
  simpleEvent : Array<SimpleEvent>
  val: string;
}
@Component({
  selector: 'dialog-overview-example-dialog',
  templateUrl: 'profile-view-popup.html',
})
export class ProfileViewPopup {

  constructor(
    public dialogRef: MatDialogRef<ProfileViewComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData) {}

  onNoClick(): void {
    this.dialogRef.close();
  }
}


