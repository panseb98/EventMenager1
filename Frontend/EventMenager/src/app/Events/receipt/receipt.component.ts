import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';


@Component({
  selector: 'app-receipt',
  templateUrl: './receipt.component.html',
  styleUrls: ['./receipt.component.css']
})

export class ReceiptComponent implements OnInit {
  [x: string]: any;
  dataSource: MatTableDataSource<PeriodicElement>;

  items : PeriodicElement[] = [
    {id: 1, itemName: 'Hydrogen', itemPrice: 1.0079, itemAmount: 1},
    {id: 2, itemName: 'Helium', itemPrice: 4.0026, itemAmount: 4},
    {id: 3, itemName: 'Lithium', itemPrice: 6.941, itemAmount: 3},
    {id: 4, itemName: 'Beryllium', itemPrice: 9.0122, itemAmount: 1},
    {id: 5, itemName: 'Boron', itemPrice: 10.811, itemAmount: 23}
  ]
  displayedColumns: string[] = ['name', 'amount', 'price', 'delete'];
  public form = new FormGroup({
      itemName : new FormControl(''),
      itemAmount : new FormControl(''),
      itemPrice : new FormControl(''),
  });

  constructor() { 
    this.dataSource = new MatTableDataSource(this.items);

  }

  ngOnInit(): void {
    //this.refresh();

  }
 getid() : number{
    let s = this.dataSource.data.map(x=> x.id).sort();
    let ss = Number(Math.max.apply(null, s));
    return ss + 1;
  }
  submit(){
    let sd : PeriodicElement = this.form.value as PeriodicElement;
    sd.id = this.getid();
    this.dataSource.data.push(sd);
    this.dataSource.filter = "";
    console.log(this.dataSource);
  }

}
export class PeriodicElement {
  id : number
  itemName : string;
  itemAmount : number;
  itemPrice : number;


}

