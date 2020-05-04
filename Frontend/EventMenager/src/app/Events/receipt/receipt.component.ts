import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { EventService } from 'src/app/services/event.service';
import { ReceiptItem } from '../Models/ReceiptItem';
import { Alert } from 'src/app/Helpers/Models/Alert';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ReturnModel } from 'src/app/Helpers/Models/ReturnModel';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-receipt',
  templateUrl: './receipt.component.html',
  styleUrls: ['./receipt.component.css']
})

export class ReceiptComponent implements OnInit {
  [x: string]: any;
  dataSource: MatTableDataSource<ReceiptItem>;
  displayedColumns: string[] = ['name', 'amount', 'price', 'delete'];
  item : ReceiptItem;
  participantId : number;
  alert : Alert;
  item2 : ReceiptItem;
  public form = new FormGroup({
      positionName : new FormControl(''),
      count : new FormControl(''),
      value : new FormControl(''),
  });

  constructor(private _service : EventService, private _mat : MatSnackBar, private route : ActivatedRoute) { 
    this.dataSource = new MatTableDataSource(this.items);
    this.alert = Alert.getInstance(_mat);
  }

  ngOnInit(): void {

    this.participantId = +this.route.snapshot.paramMap.get("participant");
    this.initItems(this.participantId);
  }
  submit(){
    this.item2 =  this.form.value as ReceiptItem;
    this.item2.participant = this.participantId;
    this.item2.value = +this.item2.value;
    this.item2.count = +this.item2.count;
    console.log(this.item2);
    this._service.addReceiptItem(this.item2).subscribe(res => {
    
      this.alert.openTopAlert(res as ReturnModel);
      this.initItems(this.participantId);
    })
  }
  private initItems(participantId : number){
    this._service.getReceiptItems(participantId).subscribe(res => {
      this.dataSource = new MatTableDataSource(res as Array<ReceiptItem>);
      this.form.reset();
    });
  }
  removeItem(receiptId : number){
    console.log(receiptId);
    this._service.removeItem(receiptId).subscribe(res => {
      this.initItems(this.participantId);
    });
  }

}


