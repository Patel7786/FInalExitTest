import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DashBoard } from 'src/app/shared/dash-board.model';
import { DashBoardService } from 'src/app/shared/dash-board.service';

@Component({
  selector: 'app-decline-form',
  templateUrl: './decline-form.component.html',
  styleUrls: ['./decline-form.component.css']
})
export class DeclineFormComponent implements OnInit {

  ID:number;
  constructor(public route:ActivatedRoute,public router:Router,public DashBoardservice:DashBoardService) { }

  ngOnInit(): void {
    const oldrecord=localStorage.getItem('userList');
    if(oldrecord==null)
    {
      this.router.navigateByUrl('');
    }
    debugger;
    this.route.params.subscribe((res)=>{
      this.ID=res['id']});

      this.DashBoardservice.getUpdate(this.ID).subscribe(d =>{
        this.DashBoardservice.ApproveDeclineData=d
        this.DashBoardservice.ApproveDeclineData.ApprovedBy=JSON.parse(localStorage.getItem('userList')!);
        
      });
      console.log(JSON.parse(localStorage.getItem('userList')!));
      
      
  }

  Decline(form:NgForm)
  {
    
    this.insertDashBoard(form);
    
  }

  insertDashBoard(myform:NgForm)
  {
    this.DashBoardservice.postDecline().subscribe(d =>{
      this.resetform(myform);
      
    });
  }

  resetform(myform:NgForm)
  {
    myform.form.reset();
    this.DashBoardservice.ApproveDeclineData=new DashBoard();
    this.router.navigateByUrl('Admin');
  }

  back()
  {
    this.router.navigateByUrl('Admin');
  }
}
