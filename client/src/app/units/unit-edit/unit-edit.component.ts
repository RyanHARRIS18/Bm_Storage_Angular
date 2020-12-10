import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router, Params } from '@angular/router';
import { UnitsService } from 'src/app/_services/units.service';
import { Unit } from 'src/app/_models/unit';
import { UnitType } from 'src/app/_models/unitType';
import { CreateUnitDTO } from 'src/app/_models/createUnitDTO';

import { NgForm } from '@angular/forms';
import { ContractFile } from 'src/app/_models/contract';
import { Subscription } from 'rxjs';


@Component({
  selector: 'app-unit-edit',
  templateUrl: './unit-edit.component.html',
  styleUrls: ['./unit-edit.component.css']
})
export class UnitEditComponent implements OnInit {
  @ViewChild('form', { static: false }) unitForm: NgForm;
  originalUnit: Unit;
  unit: Unit;
  contractFiles: ContractFile[] = null;
  editMode: boolean = false;
  hasGroup: boolean = false;
  localUnits : Unit[] = [];
  unitTypes : UnitType[] = [];
  uSubscription: any;


  constructor(private route: ActivatedRoute,
              private router: Router,
              private unitService: UnitsService) {

               }

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      let id = params['id'];
      if (!id) {
        this.editMode = false;
        return;
      }
      this.originalUnit = this.unitService.getUnit(id);
      if (!this.originalUnit) {
        return;
      }
      this.editMode = true;
      this.unit = JSON.parse(JSON.stringify(this.originalUnit));
    });
    
    this.uSubscription = this.unitService.unitTypeListChangedEvent
    .subscribe((unitTypes : UnitType[]) => {
      this.unitTypes = unitTypes;
    });
    this.unitService.getUnitTypes();
    console.log(this.unitTypes);
  }


  onSubmit() {
    console.log(this.unitForm);
    let newUnit = new CreateUnitDTO(
      this.unit ? this.unit.unitID.toString() : "",
      this.unitForm.value.unitNumber,
      this.unitForm.value.unitLocation,
      this.unitForm.value.unitTypeName,
      this.unitForm.value.unitDescription
    )

    if (this.editMode) {
      this.unitService.updateUnit(this.originalUnit, newUnit);
    } else {
      this.unitService.addUnit(newUnit);
    }
    this.onCancel();
  }

  onCancel() {
    this.editMode = false;
    this.router.navigate(['../'], { relativeTo: this.route });
  }

  isInvalidContact(newUnit: Unit) {
    if (!newUnit) {
      return true;
    }
    if (newUnit.unitNumber === this.unit.unitNumber) {
      return true;
    }
    return false;
  }
}