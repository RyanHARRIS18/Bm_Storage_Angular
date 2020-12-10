import { Component, Input, OnInit } from '@angular/core';
import { Unit } from 'src/app/_models/unit';
import { UnitsService } from 'src/app/_services/units.service';

@Component({
  selector: 'app-unit-item',
  templateUrl: './unit-item.component.html',
  styleUrls: ['./unit-item.component.css']
})
export class UnitItemComponent implements OnInit {
  @Input() unit: Unit;

  constructor(private unitService: UnitsService) { }

  ngOnInit(): void {
  }

}
