import { Component, OnInit } from '@angular/core';
import { Tenant } from '../_models/tenant';
import { TenantsService } from '../_services/tenants.service';

@Component({
  selector: 'app-tenants',
  templateUrl: './tenants.component.html',
  styleUrls: ['./tenants.component.css']
})
export class TenantsComponent implements OnInit {
  selectedTenant: Tenant;

  constructor(private tenantService: TenantsService) { }

  ngOnInit(): void {
    this.tenantService.tenantSelectedEvent.subscribe(
      (tenant: Tenant) => (this.selectedTenant = tenant)
    );
    }
  }

