import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserCalculation } from '../models/ceUserCalculation';
import { UserListProperty } from '../models/userListingProperty';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private areaBaseUri = 'api/user';

  constructor(
    private http: HttpClient
  ) { }

  getAll(): Observable<any> {
    return this.http.get<any>(this.areaBaseUri);
  }

  getAllForList(pagingModel: UserListProperty): Observable<any> {
    return this.http.post<any>(this.areaBaseUri, pagingModel);
  }

  postModel(model: UserCalculation): Observable<any> {
    return this.http.post<any>(this.areaBaseUri, model);
  }
}

