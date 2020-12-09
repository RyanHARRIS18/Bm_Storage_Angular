import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Unit } from '../_models/unit';
import { Observable, Subject } from 'rxjs';
import { UnitType } from '../_models/unitType';
import { CreateUnitDTO } from '../_models/createUnitDTO';

const httpOptions = {
  headers: new HttpHeaders({
    Authorization: 'Bearer ' + JSON.parse(localStorage.getItem('user')).token
  })
}

@Injectable({
  providedIn: 'root'
})

export class UnitsService {
  unitListChangedEvent = new Subject<Unit[]>(); 
  unitTypeListChangedEvent = new Subject<UnitType[]>(); 
  unitSelectedEvent = new Subject<Unit>(); 
  units: Unit[] = [];
  unitTypes;

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  //shorting local list
  sortAndSend() {
    this.units.sort(function (l, r) {
      return l.unitNumber - r.unitNumber;
  });
    this.unitListChangedEvent.next(this.units.slice());
  }

  //GET ALL TENANTS
  getUnits(){
     this.http.get<Unit[]>(this.baseUrl + 'unit')
     .subscribe((responseData) => {
       this.units = responseData;
       console.log(this.units)
       this.unitListChangedEvent.next(this.units);
     },
       (error: any) => {
         console.log(error);
       }
     );
}


   //Get Unit Types
   getUnitTypes() {
    this.http.get<UnitType[]>(this.baseUrl + 'unit/UnitTypes')
    .subscribe((responseData) => {
      this.unitTypes = responseData;
      console.log(this.unitTypes)
      this.unitTypeListChangedEvent.next(this.unitTypes);
    },
      (error: any) => {
        console.log(error);
      }
    );
    }
  
//CREATE
    addUnit(unit: CreateUnitDTO){
      if (!unit) {
        return;
      }
      // const strUnit = JSON.stringify(unit);
      const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
      console.log(unit);
      this.http.post<{ message: string, unit: Unit }>
      (this.baseUrl + 'unit/new', unit,{ headers: headers }).subscribe(
          (responseData) => {
            this.units.push(responseData.unit);
            this.sortAndSend();
          }
        );
        this.getUnits();
    }

//READ
  //GET TENANT BY ID
  getUnit(id: number): Unit {
    for (const unit of this.units) {
      if (unit.unitNumber == id) {
        return unit;
      }
    }
    return null;
  }

  //UPDATE
  updateUnit(originalUnit: Unit, newUnit: CreateUnitDTO){
    if (!originalUnit || !newUnit) {
      return;
    }
console.log("originalUnit");

console.log(originalUnit);

console.log("newUnit");

console.log(newUnit);


    const pos = this.units.findIndex(c => c.unitID === originalUnit.unitID);

    if (pos < 0) {
      return;
    }

    newUnit.UnitID = (originalUnit.unitID).toString();
    newUnit.UnitNumber = (newUnit.UnitNumber).toString();

    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    this.http.put<{ message: string, unit: Unit }>(this.baseUrl + 'unit/edit', newUnit,{ headers: headers }).subscribe(
      (responseData) => {
      this.units[pos] = responseData.unit;
      console.log(this.units);
      this.unitListChangedEvent.next(this.units.slice());
      });
  }

//DELETE
  deleteUnit(unit: Unit) {
    if (!unit) {
      return;
    }
    console.log(unit.unitID);
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const pos = this.units.findIndex(c => c.unitID === unit.unitID);
    if (pos < 0) {
      return;
    }
    this.http.delete(this.baseUrl + "unit/delete/?id=" + unit.unitID,{ headers: headers }).subscribe(
      (responseData) => {
        this.units.splice(pos, 1);
        this.sortAndSend();
      }
    );
  }
}




