import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user-service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  userCalcultaionList: any[];
  constructor(private userService: UserService) {

  }

  ngOnInit() {
    this.getUserCalculations();
  }

  getUserCalculations() {
    this.userService.getAll().subscribe(data => {
      this.userCalcultaionList = data.data;
    });
  }
}
