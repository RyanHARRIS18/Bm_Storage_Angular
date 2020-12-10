import { Component, OnDestroy, OnInit } from '@angular/core';
import { Tenant } from 'src/app/_models/tenant';
import { TenantsService } from 'src/app/_services/tenants.service';
import { Subscription} from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-tenant-list',
  templateUrl: './tenant-list.component.html',
  styleUrls: ['./tenant-list.component.css']
})
export class TenantListComponent implements OnInit, OnDestroy {
  private tsSubscription : Subscription;
  tenants: Tenant[] = [];

  constructor(private tenantsService: TenantsService,
              private router: Router,
              private route: ActivatedRoute) { }
 
              

  ngOnInit() {
    this.tsSubscription = this.tenantsService.tenantListChangedEvent
    .subscribe((tenants :Tenant[]) => {
      this.tenants = tenants;
    });
    this.tenantsService.getTenants();
  }

  ngOnDestroy() {
    this.tsSubscription.unsubscribe();
  }

  onNewTenant() {
    this.router.navigate(['new'], {relativeTo: this.route});
  }

}
