import { Component, OnInit } from '@angular/core';
import { state, trigger, transition, animate, style } from '@angular/animations';
import { EventService } from 'src/app/services/event.service';
import { EventVM, ReceiptItemVM } from '../Models/EventViewModel';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-single-event',
  templateUrl: './single-event.component.html',
  styleUrls: ['./single-event.component.css'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class SingleEventComponent implements OnInit {
  dataSource = ELEMENT_DATA;
  columnsToDisplay = ['name', 'surname' , 'city'];
  
 
  columnsToDisplay2 = ['user.name', 'user.surname', 'user.city'];

  expandedElement: PeriodicElement | null;
  eventData : EventVM;
  constructor(private _service : EventService, private router: Router, private authService : AuthService ,      private route : ActivatedRoute, 
    ) {
   }

  ngOnInit() {
    let event = +this.route.snapshot.paramMap.get("event");
    let userId = this.authService.decodeToken.nameid;

    this._service.getEvent(event, userId).subscribe(res => {console.log(res); this.eventData = res as EventVM});
  }
  displayedColumns = ['item', 'amount','cost'];
  transactions: Transaction[] = [
    {item: 'Beach ball', cost: 4},
    {item: 'Towel', cost: 5},
    {item: 'Frisbee', cost: 2},
    {item: 'Sunscreen', cost: 4},
    {item: 'Cooler', cost: 25},
    {item: 'Swim suit', cost: 15},
  ];

  /** Gets the total cost of all transactions. */
  getTotalCost(prices : Array<ReceiptItemVM>) {
    return prices.map(t => t.price).reduce((acc, value) => acc + value, 0);
  }
  print(ob){
    console.log(ob);
  }
  redirectToReceipt(){
    console.log(this.eventData.eventParticipant);
    this.router.navigate(['events/addReceipt/', this.eventData.eventParticipant]);
  }

}
export interface Transaction {
  item: string;
  cost: number;
}

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
  description: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {
    position: 1,
    name: 'Hydrogen',
    weight: 1.0079,
    symbol: 'H',
    description: `Hydrogen is a chemical element with symbol H and atomic number 1. With a standard
        atomic weight of 1.008, hydrogen is the lightest element on the periodic table.`
  }, {
    position: 2,
    name: 'Helium',
    weight: 4.0026,
    symbol: 'He',
    description: `Helium is a chemical element with symbol He and atomic number 2. It is a
        colorless, odorless, tasteless, non-toxic, inert, monatomic gas, the first in the noble gas
        group in the periodic table. Its boiling point is the lowest among all the elements.`
  }, {
    position: 3,
    name: 'Lithium',
    weight: 6.941,
    symbol: 'Li',
    description: `Lithium is a chemical element with symbol Li and atomic number 3. It is a soft,
        silvery-white alkali metal. Under standard conditions, it is the lightest metal and the
        lightest solid element.`
  }, {
    position: 4,
    name: 'Beryllium',
    weight: 9.0122,
    symbol: 'Be',
    description: `Beryllium is a chemical element with symbol Be and atomic number 4. It is a
        relatively rare element in the universe, usually occurring as a product of the spallation of
        larger atomic nuclei that have collided with cosmic rays.`
  }
];

interface Dictionary{
  key : string;
  value : string; 
}
