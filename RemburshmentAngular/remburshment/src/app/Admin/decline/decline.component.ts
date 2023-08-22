import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DashBoardService } from 'src/app/shared/dash-board.service';

@Component({
  selector: 'app-decline',
  templateUrl: './decline.component.html',
  styleUrls: ['./decline.component.css']
})
export class DeclineComponent implements OnInit {

  constructor(public route:ActivatedRoute,public router:Router,public DashBoardservice:DashBoardService) { }

  ngOnInit(): void {
    const oldrecord=localStorage.getItem('userList');
    if(oldrecord==null)
    {
      this.router.navigateByUrl('');
    }
    debugger;

    this.DashBoardservice.getDecline().subscribe(d=>{
      this.DashBoardservice.listApproveDecline=d
    });
  }

  back()
  {
    this.router.navigateByUrl('Admin');
  }

}
