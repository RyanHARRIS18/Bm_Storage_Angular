import { Component, OnInit } from '@angular/core';
import { Unit } from '../_models/unit';
import { UnitsService } from '../_services/units.service';

@Component({
  selector: 'app-units',
  templateUrl: './units.component.html',
  styleUrls: ['./units.component.css']
})
export class UnitsComponent implements OnInit {
  selectedUnit: Unit;

  constructor(private unitsService: UnitsService) { }

  ngOnInit(): void {
    this.unitsService.unitSelectedEvent.subscribe(
      (unit: Unit) => (this.selectedUnit = unit)
    );
  }

}
