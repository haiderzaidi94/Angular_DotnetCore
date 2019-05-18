import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MembersListComponent } from './members/members-list/members-list.component';
import { MessagesComponent } from './messages/messages.component';
import { RegisterComponent } from './register/register.component';
import { ListsComponent } from './lists/lists.component';
import { AuthGuard } from './_guard/auth.guard';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { MemberDetailResolver } from './_resolvers/member-detail.resolver';
import { MemberListResolver } from './_resolvers/member-list.resolver';

export const appRoutes: Routes = [
    { path : '', component : HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'members-list', component: MembersListComponent, resolve:{users : MemberListResolver}},
            { path: 'member/:id', component: MemberDetailComponent , resolve:{user : MemberDetailResolver}},
            { path: 'messages', component: MessagesComponent },
            { path: 'lists', component: ListsComponent }
        ]
    },
    { path: 'register', component: RegisterComponent },
    { path: '**', redirectTo: '', pathMatch: 'full'},
];


