import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { DashBoard } from '../dash-board.model';
import { DashBoardService } from '../dash-board.service';
import { SignUpService } from '../sign-up.service';

@Component({
  selector: 'app-remburshment-form',
  templateUrl: './remburshment-form.component.html',
  styleUrls: ['./remburshment-form.component.css']
})
export class RemburshmentFormComponent implements OnInit {

  constructor(public DashBoardservice:DashBoardService,public signupservice:SignUpService,private router:Router) 
  { 
    const oldrecord=localStorage.getItem('userList');
   
    
  }

  ngOnInit(): void {
    const oldrecord=localStorage.getItem('userList');
    if(oldrecord==null)
    {
      this.router.navigateByUrl('');
    }
    debugger;
    this.DashBoardservice.getRemburshment().subscribe(d =>{
      this.DashBoardservice.listRemburshment=d
    });
    this.DashBoardservice.getCurrency().subscribe(d =>{
      this.DashBoardservice.listCurrency=d
    })

    this.DashBoardservice.DashBoardData.Email=this.signupservice.getLogin();

    
        

    
  }


  submit(form:NgForm)
  {
    
    this.insertDashBoard(form);
    
  }

  insertDashBoard(myform:NgForm)
  {
    this.DashBoardservice.saveDashBoard().subscribe(d =>{
      this.resetform(myform);
      
    });
  }

  resetform(myform:NgForm)
  {
    myform.form.reset();
    this.DashBoardservice.DashBoardData=new DashBoard();
    this.router.navigateByUrl('DashBoard');
  }

  back()
  {
    this.router.navigateByUrl('DashBoard');
  }
}
