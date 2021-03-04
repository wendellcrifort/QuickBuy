import { Component, OnInit } from "@angular/core"
import { Usuario } from "../../model/usuario";
import { UsuarioServico } from "../../servicos/usuario/usuario.servico";

@Component({
  selector: "cadastro-usuario",
  templateUrl: "./cadastro.usuario.component.html",
  styleUrls: ["./cadastro.usuario.component.css"],
})

export class CadastroUsuarioComponent implements OnInit {
  public usuario: Usuario;
  public usuarioCadastrado: boolean;
  public mensagem: string;
  public ativarspinner: boolean

  constructor(private usuarioServico: UsuarioServico) {

  }

  ngOnInit(): void {
    this.usuario = new Usuario();    
  }

  public cadastrar() {
    this.ativarspinner = true;
    this.usuarioServico.cadastrarUsuario(this.usuario)
      .subscribe(
        data => {
          this.usuarioCadastrado = true;
          this.mensagem = ""
          this.ativarspinner = false
        },
        err => {
          this.usuarioCadastrado = false;
          this.mensagem = err.error
          this.ativarspinner = false
        }
      );
  }
}
