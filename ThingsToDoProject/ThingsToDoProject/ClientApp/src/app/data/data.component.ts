import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-data',
  templateUrl: './data.component.html',
  styleUrls: ['./data.component.css']
})
export class DataComponent implements OnInit {
  response: any;
  constructor(private route: ActivatedRoute, private router: Router , private http: HttpClient) { 
    console.log(this.router.url,"Current URL");
    
}

  ngOnInit() {
    this.http.get('http://localhost:63661/api/InsideAirport').
    subscribe((response)=>
    {
    this.response = response;
   // console.log(this.response);
    })
    // console.log(this.route.snapshot.queryParamMap.has('location'));
    // console.log(this.route.snapshot.queryParamMap.get('location'));
    // console.log(this.route.snapshot.queryParamMap.has('time'));
    // console.log(this.route.snapshot.queryParamMap.get('time'));
    // console.log(this.route.snapshot.queryParamMap.keys);
  }

}
