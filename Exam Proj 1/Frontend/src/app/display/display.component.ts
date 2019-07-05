import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-display',
  templateUrl: './display.component.html',
  styleUrls: ['./display.component.css']
})
export class DisplayComponent implements OnInit {

  process: Process[];

  constructor() { }

  ngOnInit() {
    this.fetchProcesses();
  }

  fetchProcesses(){
    this.processService
      .getProcess()
      .subscribe((data: Process[]) => {
        this.process = data;
        console.log('Data requested...');
        console.log(this.process);
      });
  }

  updateProcesses(){

  }

}
