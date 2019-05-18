import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BsDropdownModule, TabsModule } from 'ngx-bootstrap';
import { Routes, RouterModule } from '@angular/router';

import { AuthService } from './_services/auth.service';
import { UserService } from './_services/user.service';
import { AlertifyService } from './_services/alertify.service';


import { AppComponent } from './app.component';
import { ValueComponent } from './value/value.component';
import { RegisterComponent } from './register/register.component';
import { MembersListComponent } from './members/members-list/members-list.component';
import { ListsComponent } from './lists/lists.component';
import { MessagesComponent } from './messages/messages.component';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';


import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { appRoutes } from './routes';
import { AuthGuard } from './_guard/auth.guard';
import { MemberCardComponent } from './members/member-card/member-card.component';
import { JwtModule } from '@auth0/angular-jwt';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { NgxGalleryModule } from 'ngx-gallery';
import { MemberDetailResolver } from './_resolvers/member-detail.resolver';
import { MemberListResolver } from './_resolvers/member-list.resolver';


export function TokenGetter(){
   return localStorage.getItem('token');
}

@NgModule({
   declarations: [
      AppComponent,
      ValueComponent,
      NavComponent,
      RegisterComponent,
      HomeComponent,
      MembersListComponent,
      ListsComponent,
      MessagesComponent,
      MemberCardComponent,
      MemberDetailComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule,
      NgxGalleryModule,
      FormsModule,
      BsDropdownModule.forRoot(),
      TabsModule.forRoot(),
      RouterModule.forRoot(appRoutes),
      JwtModule.forRoot({
         config:{
            tokenGetter: TokenGetter,
            whitelistedDomains : ['localhost:50043'],
            blacklistedRoutes : ['localhost:50043/api/auth']
         }
      })
   ],
   providers: [
      AuthService,
      UserService,
      AlertifyService,
      AuthGuard,
      MemberDetailResolver,
      MemberListResolver
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
