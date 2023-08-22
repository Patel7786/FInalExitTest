import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DashBoardService } from 'src/app/shared/dash-board.service';

@Component({
  selector: 'app-approve',
  templateUrl: './approve.component.html',
  styleUrls: ['./approve.component.css']
})
export class ApproveComponent implements OnInit {

  constructor(public route:ActivatedRoute,public router:Router,public DashBoardservice:DashBoardService) { }

  ngOnInit(): void 
  {
    const oldrecord=localStorage.getItem('userList');
    if(oldrecord==null)
    {
      this.router.navigateByUrl('');
    }

    debugger;
    
    this.DashBoardservice.getApprove().subscribe(d=>{
      this.DashBoardservice.listApproveDecline=d
    });
    console.log(this.DashBoardservice.listApproveDecline);
    
  }

  back()
  {
    this.router.navigateByUrl('Admin');
  }

}
