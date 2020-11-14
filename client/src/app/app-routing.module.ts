import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { HomeComponent } from './home/home.component';
import { MessagesComponent } from './messages/messages.component';
import { TenantDetailComponent } from './tenants/tenant-detail/tenant-detail.component';
import { TenantItemComponent } from './tenants/tenant-item/tenant-item.component';
import { TenantListComponent } from './tenants/tenant-list/tenant-list.component';
import { TenantsComponent } from './tenants/tenants.component';
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

