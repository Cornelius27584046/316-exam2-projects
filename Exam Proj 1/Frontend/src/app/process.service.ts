import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class IssueService {

  uri = 'http://localhost:3000/api';

  constructor(private http: HttpClient) {  }

  getProcesses() {
    return this.http.get(`${this.uri}/process/get`);
  }

  addProcess(name, ArrivalTime, BurstTime, TurnaroundTime, WaitTime, ReactTime) {
    const process = {
      name: name,
      ArrivalTime: ArrivalTime,
      BurstTime: BurstTime,
      TurnaroundTime: TurnaroundTime,
      WaitTime: WaitTime,
      ReactTime: ReactTime
    };

    return this.http.post(`${this.uri}/process/create`, process);
  }

  updateProcess(_id, name, ArrivalTime, BurstTime, TurnaroundTime, WaitTime, ReactTime) {
    const process = {
      name: name,
      ArrivalTime: ArrivalTime,
      BurstTime: BurstTime,
      TurnaroundTime: TurnaroundTime,
      WaitTime: WaitTime,
      ReactTime: ReactTime
    };

    return this.http.post(`${this.uri}/process/update/${_id}`, process);
  }
  //add create and delete table
}
