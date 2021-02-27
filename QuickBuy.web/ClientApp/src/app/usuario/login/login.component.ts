import { Component } from "@angular/core"
import { Usuario } from "../../model/usuario"
import { ActivatedRoute, Router } from "@angular/router"
import { UsuarioServico } from "../../servicos/usuario/usuario.servico";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"]  
})

export class LoginComponent {
  public usuario;  
  public returnUrl: string
  public mensagem: string;

  constructor(private router: Router,
    private actvatedRouter: ActivatedRoute,
    private usuarioServico: UsuarioServico) {

    this.usuario = new Usuario();
    this.returnUrl = this.actvatedRouter.snapshot.queryParams['returnUrl']
  }

  entrar() {

    this.usuarioServico.verificarUsuario(this.usuario)
      .subscribe(
        data => {
          this.usuarioServico.usuario = data
          
          if (this.returnUrl === undefined) {
            this.router.navigate(['/']);
          } else {
            this.router.navigate([this.returnUrl]);
          }
          
        },
        err => {
          this.mensagem = err.error;
        }
      );    
  }
}
