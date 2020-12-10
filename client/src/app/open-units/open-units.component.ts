import { Component, OnInit } from '@angular/core';
import { Unit } from '../_models/unit';
import { UnitsService } from '../_services/units.service';

@Component({
  selector: 'app-open-units',
  templateUrl: './open-units.component.html',
  styleUrls: ['./open-units.component.css']
})
export class OpenUnitsComponent implements OnInit {
  selectedUnit: Unit;

  constructor(private unitsService: UnitsService) { }

  ngOnInit(): void {
    this.unitsService.unitSelectedEvent.subscribe(
      (unit: Unit) => (this.selectedUnit = unit)
    );
  }

}
