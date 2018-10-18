import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})
export class MapComponent implements OnInit{
  title: string = 'My first AGM project';
  lat: number =18.5793;
  lng: number = 73.9089;
  Getresponse:any;
  iconUrl: string = "assets/images/icons8-user-location-48.png";
  public origin: any; 
  public destination: any;
 city:string;
  getDirection(marker,latitude: number,longitude: number) {
    console.log(this.Getresponse);
    this.origin = { lat:Number(this.Getresponse[0].latitudePosition), lng: Number(this.Getresponse[0].longitudePosition)};
    console.log(origin);
    this.destination = { lat: latitude, lng: longitude}
  }
  closeInfoWindow(infoWindow,gm)
  {
    console.log('amakh');
    if (gm.lastOpen != null) {
      gm.lastOpen.close();
  }

  }
  onMouseOver(infoWindow, gm) {

    if (gm.lastOpen != null) {
        gm.lastOpen.close();
    }

    gm.lastOpen = infoWindow;

    infoWindow.open();
}

  public renderOptions = {
    suppressMarkers: true,
}
constructor(private route: ActivatedRoute, private router: Router , private http: HttpClient) { 
  console.log(this.router.url,"Current URL");
  console.log(this.city= this.route.snapshot.queryParamMap.get('location'));
  this.http.get('http://localhost:63661/api/InsideAirport/'+this.city).subscribe((response)=>{
    this.Getresponse = response;
    console.log("New Response");
    console.log(this.Getresponse);
  })
}
markers: Array<marker>=[];
response: any;
  ngOnInit() {
 this.http.get('http://localhost:63661/api/InsideAirport').
  subscribe((response)=>
  {
  this.response = response;

  for(let data in response){
    this.markers.push({
      lat: Number(response[data].longitute),
      lng: Number(response[data].latitude),
      name:response[data].name,
      rating:response[data].rating,

    })
  }
})
}
}
class marker {
  lat: number;
  lng: number;
  
name:string;
rating:string

}
  
