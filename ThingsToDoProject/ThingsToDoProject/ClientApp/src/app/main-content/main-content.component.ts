import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-main-content',
  templateUrl: './main-content.component.html',
  styleUrls: ['./main-content.component.css']
})
export class MainContentComponent implements OnInit {

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    console.log(this.route.snapshot.queryParamMap.has('location'));
    console.log(this.route.snapshot.queryParamMap.get('location'));
    console.log(this.route.snapshot.queryParamMap.has('time'));
    console.log(this.route.snapshot.queryParamMap.get('time'));
  }
}
