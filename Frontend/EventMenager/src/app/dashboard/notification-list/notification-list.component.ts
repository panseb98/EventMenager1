import { Component, OnInit } from '@angular/core';
import { NotyficationtoList } from '../Models/notification';


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

  ELEMENT_DATA: NotyficationtoList[] = [
    {lp: 1,notificationName: 'Użytkownik Maciej Musiał dodał cie do znajomych.', isNew: true, isNotificationAccept: true, buttonDisable: false, buttonName: "Zatwierdź"},
    {lp: 2,notificationName: 'Użytkownik Jarosław Kaczyński dodał cie do znajomych.', isNew: true, isNotificationAccept: true, buttonDisable: false, buttonName: "Zatwierdź"},
    {lp: 3,notificationName: 'Użytkownik Robert Lewandowski dodał cie do znajomych.', isNew: true, isNotificationAccept: true, buttonDisable: false, buttonName: "Zatwierdź"},
    {lp: 4,notificationName: 'Team Cerber ', isNew: false, isNotificationAccept: false, buttonDisable: false, buttonName: "Zatwierdź"},
  ];
  displayedColumns: string[] = ['position', 'name', 'weight'];
  dataSource = this.ELEMENT_DATA;
  constructor() {
    
   }

  ngOnInit(): void {
  }
  setNot(id : number){
    let element = this.ELEMENT_DATA.find(x => x.lp == id);
    element.isNew = false;
    element.isNotificationAccept = false;
    element.buttonDisable = true;
    element.buttonName = "Zatwierdzono";
    this.ELEMENT_DATA = this.ELEMENT_DATA.map(item => item.lp == id ? element : item);
    console.log("setNot", element);
  }

}
