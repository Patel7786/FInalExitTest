import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DashBoard } from '../dash-board.model';
import { DashBoardService } from '../dash-board.service';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit {

  ID:number
  constructor(public route:ActivatedRoute,public router:Router,public DashBoardservice:DashBoardService)
   { 
    this.route.params.subscribe((res)=>{
      this.ID=res['id']});
   }

  ngOnInit(): void 
  {
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
    });

    this.DashBoardservice.getUpdate(this.ID).subscribe(d =>{
      this.DashBoardservice.UpdateData=d
    });
    
    
    
  }
  
  Update(form:NgForm)
  {
    
    this.insertDashBoard(form);
    
  }

  insertDashBoard(myform:NgForm)
  {
    this.DashBoardservice.postUpdate(this.ID).subscribe(d =>{
      this.resetform(myform);
      
    });
  }

  resetform(myform:NgForm)
  {
    myform.form.reset();
    this.DashBoardservice.UpdateData=new DashBoard();
    this.router.navigateByUrl('DashBoard');
  }

  back()
  {
    this.router.navigateByUrl('DashBoard');
  }
}
