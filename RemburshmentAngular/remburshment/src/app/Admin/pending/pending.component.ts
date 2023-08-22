import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DashBoardService } from 'src/app/shared/dash-board.service';

@Component({
  selector: 'app-pending',
  templateUrl: './pending.component.html',
  styleUrls: ['./pending.component.css']
})
export class PendingComponent implements OnInit {

  constructor(private router:Router,public Dashboardservice:DashBoardService) { }

  ngOnInit(): void {

    const oldrecord=localStorage.getItem('userList');
    if(oldrecord==null)
    {
      this.router.navigateByUrl('');
    }
    debugger;
    
    this.Dashboardservice.getDashBoard().subscribe(d=>
      {
        this.Dashboardservice.listDashBoard=d;
      });
      
      
  }
  
  

}
