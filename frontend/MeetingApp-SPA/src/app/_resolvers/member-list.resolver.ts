import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Router, Resolve } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { User } from '../_model/User';
import { UserService } from '../_services/user.service';
import { AlertifyService } from '../_services/alertify.service';

@Injectable()
export class MemberListResolver implements Resolve<User> {

    resolve(route: ActivatedRouteSnapshot) : Observable<User> {
        return this.user.getUsers().pipe(
            catchError(error => {
                this.alertify.error(error);
                this.router.navigate(['']);
                return of(null);
            })
        );
    }
    
    /**
     *
     */
    constructor(private user: UserService, private router: Router, private alertify: AlertifyService) {
        
    }
}