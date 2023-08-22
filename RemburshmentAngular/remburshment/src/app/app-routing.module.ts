import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ApprovalFormComponent } from './Admin/approval-form/approval-form.component';
import { ApproveComponent } from './Admin/approve/approve.component';
import { DeclineFormComponent } from './Admin/decline-form/decline-form.component';
import { DeclineComponent } from './Admin/decline/decline.component';
import { PendingComponent } from './Admin/pending/pending.component';
import { AppComponent } from './app.component';
import { DashBoardComponent } from './shared/dash-board/dash-board.component';
import { LoginComponent } from './shared/login/login.component';
import { RemburshmentFormComponent } from './shared/remburshment-form/remburshment-form.component';
import { SignUPComponent } from './shared/sign-up/sign-up.component';
import { UpdateComponent } from './shared/update/update.component';

const routes: Routes = [
  {
  path:'SignUp',
  component:SignUPComponent
  },
  {
    path:'',
    component:LoginComponent
  },
  {
    path:'DashBoard',
    component:DashBoardComponent
  },
  {
    path:'RemburshmentForm',
    component:RemburshmentFormComponent
  },
  {
    path:'DashBoard/Update/:id',
    component:UpdateComponent
  },
  {
    path:'Admin',
    component:PendingComponent
  },
  {
    path:'Approve',
    component:ApproveComponent
  },
  {
    path:'Decline',
    component:DeclineComponent
  },
  {
    path:'Admin/approve/:id',
    component:ApprovalFormComponent
  },
  {
    path:'Admin/decline/:id',
    component:DeclineFormComponent
  }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { 

  
}
