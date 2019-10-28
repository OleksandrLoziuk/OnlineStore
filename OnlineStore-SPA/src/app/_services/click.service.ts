import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ClickService {

  _some: boolean;

constructor() { }

setClick(some: boolean){
  this._some = some;
}

getClick(){
  return this._some;
}

}
