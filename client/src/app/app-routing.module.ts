import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { HomeComponent } from './home/home.component';
import { MessagesComponent } from './messages/messages.component';
import { OpenUnitsDetailComponent } from './open-units/open-units-detail/open-units-detail.component';
import { OpenUnitsItemComponent } from './open-units/open-units-item/open-units-item.component';
import { OpenUnitsComponent } from './open-units/open-units.component';
import { TenantDetailComponent } from './tenants/tenant-detail/tenant-detail.component';
import { TenantItemComponent } from './tenants/tenant-item/tenant-item.component';
import { TenantListComponent } from './tenants/tenant-list/tenant-list.component';
import { TenantsComponent } from './tenants/tenants.component';
import { UnitDetailComponent } from './units/unit-detail/unit-detail.component';
import { UnitEditComponent } from './units/unit-edit/unit-edit.component';
import { UnitItemComponent } from './units/unit-item/unit-item.component';
import { UnitsComponent } from './units/units.component';
import { AuthGuard } from './_guards/auth.guard';
import { AccountService } from './_services/account.service';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'tenants', component: TenantsComponent, canActivate:[AuthGuard],
  children: [
    {path: 'new', component: TenantItemComponent},
    {path: ':id', component: TenantDetailComponent},
    {path: ':id/edit', component: TenantDetailComponent},
  ]},
  {path: 'units', component: UnitsComponent, canActivate:[AuthGuard],
  children: [
    {path: 'new', component: UnitEditComponent},
    {path: ':id', component: UnitDetailComponent},
    {path: ':id/edit', component: UnitEditComponent},
  ]},
  {path: 'openunits', component: OpenUnitsComponent, canActivate:[AuthGuard],
  children: [
    {path: 'new', component: OpenUnitsItemComponent},
    {path: ':id', component: OpenUnitsDetailComponent},
    {path: ':id/edit', component: OpenUnitsDetailComponent},
  ]},
  {path: 'errors', component: TestErrorsComponent},
  {path: 'not-found', component: NotFoundComponent},
  {path: 'server-error', component: ServerErrorComponent},
  {path: '**', component: NotFoundComponent, pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

