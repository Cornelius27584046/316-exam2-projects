import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Process } from '../../process.model';
import { ProcessService } from '../../process.service';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {

  constructor(private issueService: IssueService, private router: Router) { }

  ngOnInit() {
  }

  moveOn(){
    this.router.navigate([`/display`]);
  }
}
