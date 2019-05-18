import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/_services/user.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { User } from 'src/app/_model/User';
import { ActivatedRouteSnapshot, ActivatedRoute } from '@angular/router';
import { NgxGalleryOptions, NgxGalleryImage, NgxGalleryAnimation } from 'ngx-gallery';

@Component({
  selector: 'app-member-detail',
  templateUrl: './member-detail.component.html',
  styleUrls: ['./member-detail.component.css']
})
export class MemberDetailComponent implements OnInit {

  user: User;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];
 
  constructor(private _user: UserService, private alertify: AlertifyService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe((data)=>{
      this.user = data['user'];
    });
    this.InitGallery();
    this.galleryImages = this.GetImages();
  }



  InitGallery() {
    this.galleryOptions = [
      {
          width: '600px',
          height: '400px',
          thumbnailsColumns: 4,
          imageAnimation: NgxGalleryAnimation.Slide
      },
      // max-width 800
      {
          breakpoint: 800,
          width: '100%',
          height: '600px',
          imagePercent: 80,
          thumbnailsPercent: 20,
          thumbnailsMargin: 20,
          thumbnailMargin: 20
      },
      // max-width 400
      {
          breakpoint: 400,
          preview: false
      }
  ];
  }

  GetImages() {
    console.log(this.user);
    const photos = [];
    for (let i = 0; i < this.user.photos.length ; i++){
      photos.push({
        small : this.user.photos[i].url,
        medium : this.user.photos[i].url,
        big : this.user.photos[i].url,
      });
    }
    return photos;
  }

}
