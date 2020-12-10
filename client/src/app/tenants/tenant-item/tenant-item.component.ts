import { Component, Input, OnInit } from '@angular/core';
import { Tenant } from 'src/app/_models/tenant';
import { TenantsService } from 'src/app/_services/tenants.service';

@Component({
  selector: 'app-tenant-item',
  templateUrl: './tenant-item.component.html',
  styleUrls: ['./tenant-item.component.css']
})
export class TenantItemComponent {
  @Input() tenant: Tenant;

  constructor(private tenantService: TenantsService) { }


}
