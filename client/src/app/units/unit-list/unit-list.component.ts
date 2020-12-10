import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Unit } from 'src/app/_models/unit';
import { UnitsService } from 'src/app/_services/units.service';

@Component({
  selector: 'app-unit-list',
  templateUrl: './unit-list.component.html',
  styleUrls: ['./unit-list.component.css']
})
export class UnitListComponent implements OnInit, OnDestroy {
  private uSubscription : Subscription;
  units: Unit[] = [];

  constructor(private unitsService: UnitsService,
              private router: Router,
              private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.uSubscription = this.unitsService.unitListChangedEvent
    .subscribe((units : Unit[]) => {
      this.units = units;
    });
    this.unitsService.getUnits();
  }

  ngOnDestroy() {
    this.uSubscription.unsubscribe();
  }

  onNewUnit(){
    this.router.navigate(['new'], {relativeTo: this.route});
  }

}
