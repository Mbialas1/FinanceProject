import { Component } from '@angular/core';
import { AuthService } from '../../auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

  constructor(private authService: AuthService) {}

  ngOnInit(): void {
    this.authService.login('testUser', 'test123').subscribe(
      (response: any) => {
        this.authService.setToken(response.token);
        if (this.authService.isLoggedIn()) {
          console.log('User is logged in!');
        }
      },
      (error) => {
        console.error('Login error:', error);
      }
    );
}
}