import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../_model/User';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

constructor(private http: HttpClient) { }

 baseUrl = environment.apiUrl;

getUsers(): Observable<User[]> {
  return this.http.get<User[]>(this.baseUrl + 'users');
}

getUser(id): Observable<User> {
  return this.http.get<User>(this.baseUrl + 'users/' + id);
}

}
