import { Injectable } from '@angular/core';
import { User } from '../_model/User';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { UserService } from '../_services/user.service';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class MemberDetailResolver implements Resolve<User> {
    resolve(route: ActivatedRouteSnapshot) : Observable<User> {
        return this.user.getUser(route.params['id']).pipe(
            catchError(error => {
                this.alertify.error(error);
                this.router.navigate(['/members-list']);
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