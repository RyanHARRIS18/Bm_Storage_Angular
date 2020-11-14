import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Tenant } from 'src/app/_models/tenant';
import { TenantsService } from 'src/app/_services/tenants.service';
import { WindRefService } from 'src/app/_services/wind-ref.service';


@Component({
  selector: 'app-tenant-detail',
  templateUrl: './tenant-detail.component.html',
  styleUrls: ['./tenant-detail.component.css']
})
export class TenantDetailComponent implements OnInit {
  tenant: Tenant;
  id: number;
  nativeWindow: any;

  constructor(
    private tenantService: TenantsService,
    private route: ActivatedRoute,
    private router: Router,
     private windRefService: WindRefService) {}

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.id = params["id"];
      this.tenant = this.tenantService.getTenant(this.id);
    });
    this.nativeWindow = this.windRefService.getNativeWindow();
  }

  // onView() {
  //   if (this.tenant.url) {
  //     this.nativeWindow.open(this.document.url);
  //   }
  // }

}
