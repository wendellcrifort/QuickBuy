import { Component } from "@angular/core"
import { Usuario } from "../../model/usuario"
import { ActivatedRoute, Router } from "@angular/router"

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"]  
})

export class LoginComponent {
  public usuario;  
  public returnUrl: string

  constructor(private router: Router, private actvatedRouter: ActivatedRoute) {
    this.usuario = new Usuario();
    this.returnUrl = this.actvatedRouter.snapshot.queryParams['returnUrl']

  }

  entrar() {
    if (this.usuario.email == "wendell@teste.com" && this.usuario.senha == "123") {
      sessionStorage.setItem("usuario-autenticado", "1");      
      if (this.returnUrl === undefined) {        
        this.router.navigate(['/']) 
      }
      else {
        this.router.navigate([this.returnUrl])
      }     
    }
  }

  usuarioLogado() {

  }

  sair() {

  }
}
