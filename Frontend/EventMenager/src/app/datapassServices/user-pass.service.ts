import { Injectable } from '@angular/core';
import { Subject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserPassService {
  private userId$ =  new Subject<number>();
  setUserId(userId : number){
    this.userId$.next(userId);
  }

  getUserId() : Observable<number>{
    return this.userId$.asObservable();
  }
}
