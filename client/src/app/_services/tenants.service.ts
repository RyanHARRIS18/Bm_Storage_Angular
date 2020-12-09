import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Tenant } from '../_models/tenant';
import { Observable, Subject } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({
    Authorization: 'Bearer ' + JSON.parse(localStorage.getItem('user')).token
  })
}

@Injectable({
  providedIn: 'root'
})

export class TenantsService {
  tenantListChangedEvent = new Subject<Tenant[]>(); 
  tenantSelectedEvent = new Subject<Tenant>(); 
  tenants: Tenant[] = [];

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  //GET ALL TENANTS
  getTenants(){
    this.http.get<Tenant[]>(this.baseUrl + 'users', httpOptions)
    .subscribe((responseData) => {
      this.tenants = responseData;
      this.tenantListChangedEvent.next(this.tenants);
    },
      (error: any) => {
        console.log(error);
      }
    );
}
  

  //GET TENANT BY ID
  getTenant(id: number): Tenant {
    for (const tenant of this.tenants) {
      if (tenant.id == id) {
        return tenant;
      }
    }
    return null;
  }

}
