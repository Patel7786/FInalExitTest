import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { SignUPComponent } from './shared/sign-up/sign-up.component';
import { LoginComponent } from './shared/login/login.component';
import { HeaderComponent } from './shared/header/header.component';
import { DashBoardComponent } from './shared/dash-board/dash-board.component';
import { RemburshmentFormComponent } from './shared/remburshment-form/remburshment-form.component';
import { UpdateComponent } from './shared/update/update.component';
import { PendingComponent } from './Admin/pending/pending.component';
import { AHeaderComponent } from './Admin/aheader/aheader.component';
import { ApproveComponent } from './Admin/approve/approve.component';

import { DeclineComponent } from './Admin/decline/decline.component';
import { ApprovalFormComponent } from './Admin/approval-form/approval-form.component';
import { DeclineFormComponent } from './Admin/decline-form/decline-form.component';

@NgModule({
  declarations: [
    AppComponent,
    SignUPComponent,
    LoginComponent,
    HeaderComponent,
    DashBoardComponent,
    RemburshmentFormComponent,
    UpdateComponent,
    PendingComponent,
    AHeaderComponent,
    ApproveComponent,
    DeclineComponent,
    ApprovalFormComponent,
    DeclineFormComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
