import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { AddEventComponent } from './Events/add-event/add-event.component';
import { EventListComponent } from './Events/event-list/event-list.component';
import { SingleEventComponent } from './Events/single-event/single-event.component';
import { NotificationListComponent } from './dashboard/notification-list/notification-list.component';
import { ReceiptComponent } from './Events/receipt/receipt.component';
import { LoginComponent } from './authorization/login/login.component';
import { RegisterComponent } from './authorization/register/register.component';
import { ProfileViewComponent } from './Users/profile-view/profile-view.component';
import { UserListComponent } from './authorization/user-list/user-list.component';

const routes: Routes = [
  {path : 'events/addEvent', component: AddEventComponent},
  {path : 'events/listEvents', component: EventListComponent},
  {path : 'events/singleEvent', component: SingleEventComponent},
  {path : 'events/addReceipt', component: ReceiptComponent},
  {path : 'notification', component: NotificationListComponent},
  {path : '', component: DashboardComponent},
  {path : 'login', component: LoginComponent},
  {path : 'register', component: RegisterComponent},
  {path : 'user/view/:user', component: ProfileViewComponent},
  {path : 'user/list', component: UserListComponent}






];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
