import { Component, Input, OnInit } from '@angular/core';
import { Unit } from 'src/app/_models/unit';
import { UnitsService } from 'src/app/_services/units.service';

@Component({
  selector: 'app-open-units-item',
  templateUrl: './open-units-item.component.html',
  styleUrls: ['./open-units-item.component.css']
})
export class OpenUnitsItemComponent implements OnInit {
  @Input() unit: Unit;

  constructor(private unitService: UnitsService) { }

  ngOnInit(): void {
  }

}
