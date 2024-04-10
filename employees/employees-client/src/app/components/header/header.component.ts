import { Component } from '@angular/core';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatButtonModule } from '@angular/material/button';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [
    MatTooltipModule,
    MatButtonModule,
  ],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {

  constructor(private route: Router) { }
  toHomePage() {
    this.route.navigate(['allemployees']);
  }
  toAddEmployee(){
    this.route.navigate(['addemployee']);
  }
  toAbout(){
    this.route.navigate(['about']);
  }
}
