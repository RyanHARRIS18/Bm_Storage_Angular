import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Unit } from 'src/app/_models/unit';
import { UnitsService } from 'src/app/_services/units.service';
import { WindRefService } from 'src/app/_services/wind-ref.service';

@Component({
  selector: 'app-open-units-detail',
  templateUrl: './open-units-detail.component.html',
  styleUrls: ['./open-units-detail.component.css']
})
export class OpenUnitsDetailComponent implements OnInit {
  unit: Unit;
  unitNumber: number;
  nativeWindow: any;

  constructor( 
    private unitService: UnitsService,
    private route: ActivatedRoute,
    private router: Router,
     private windRefService: WindRefService) {}

  ngOnInit(): void { this.route.params.subscribe((params: Params) => {
    this.unitNumber = params["id"];
    this.unit = this.unitService.getUnit(this.unitNumber);
  });
  this.nativeWindow = this.windRefService.getNativeWindow();
}


}
