import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { TenantsComponent } from './tenants/tenants.component';
import { TenantListComponent } from './tenants/tenant-list/tenant-list.component';
import { TenantDetailComponent } from './tenants/tenant-detail/tenant-detail.component';
import { ListsComponent } from './lists/lists.component';
import { MessagesComponent } from './messages/messages.component';
import { ToastrModule } from 'ngx-toastr';
import { SharedModule } from './_modules/shared.module';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { TenantItemComponent } from './tenants/tenant-item/tenant-item.component';
import { UnitsComponent } from './units/units.component';
import { UnitListComponent } from './units/unit-list/unit-list.component';
import { UnitItemComponent } from './units/unit-item/unit-item.component';
import { UnitDetailComponent } from './units/unit-detail/unit-detail.component';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import { OpenUnitsComponent } from './open-units/open-units.component';
import { MyUnitsComponent } from './my-units/my-units.component';
import { OpenUnitsListComponent } from './open-units/open-units-list/open-units-list.component';
import { OpenUnitsItemComponent } from './open-units/open-units-item/open-units-item.component';
import { OpenUnitsDetailComponent } from './open-units/open-units-detail/open-units-detail.component';
import { UnitEditComponent } from './units/unit-edit/unit-edit.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    TenantsComponent,
    TenantListComponent,
    TenantDetailComponent,
    ListsComponent,
    MessagesComponent,
    TestErrorsComponent,
    NotFoundComponent,
    ServerErrorComponent,
    TenantItemComponent,
    UnitsComponent,
    UnitListComponent,
    UnitItemComponent,
    UnitDetailComponent,
    OpenUnitsComponent,
    MyUnitsComponent,
    OpenUnitsListComponent,
    OpenUnitsItemComponent,
    OpenUnitsDetailComponent,
    UnitEditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    BrowserAnimationsModule,
    SharedModule
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true},
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
