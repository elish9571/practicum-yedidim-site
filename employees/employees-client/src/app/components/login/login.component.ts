import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AdminService } from '../../admin/admin.service';
import { Router } from '@angular/router';
import { Admin } from '../../admin/admin.model'
@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public loginForm: FormGroup = new FormGroup({
    "name": new FormControl(null, [Validators.required]),
    "password": new FormControl(null, [Validators.required])
  });
  public admin!: Admin;
  errorMessage: string = '';

  constructor(private adminService: AdminService, private router: Router) { }

  ngOnInit(): void {
    // Initialize the login form
    this.loginForm = new FormGroup({
      name: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required)
    });
  }

  async checkUserExists() {
    if (this.loginForm.invalid) {
      this.errorMessage = 'Please fill in all required fields.';
      return;
    }
    const { name, password } = this.loginForm.value;
    try {
      const isAuthenticated = await this.adminService.getAdmin(name, password);

      if (isAuthenticated) {
        sessionStorage.setItem('isAuthenticated', 'true');
        this.router.navigate(['/allemployees']);
      } else {
        this.errorMessage = 'Invalid username or password';
      }
    } catch (error) {
      console.error('Error occurred during authentication:', error);
      this.errorMessage = 'An error occurred. Please try again later.';
    }
  }
  log() {
    this.router.navigate(['/allemployees']);
  }

}
