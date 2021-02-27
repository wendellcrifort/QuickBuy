import { Injectable, Inject } from "@angular/core"
import { HttpClient, HttpHeaders } from "@angular/common/http"
import { Observable } from "rxjs"
import { Usuario } from "../../model/usuario"

@Injectable({
  providedIn: "root"
})

export class UsuarioServico {
  private baseUrl: string
  private _usuario: Usuario;

  get usuario(): Usuario {
    let usuario_json = sessionStorage.getItem("usuario-autenticado");
    this._usuario = JSON.parse(usuario_json);
    return this._usuario;
  }

  set usuario(usuario: Usuario) {
    sessionStorage.setItem("usuario-autenticado", JSON.stringify(usuario));    
    this._usuario = usuario
  }

  constructor(private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string) {

    this.baseUrl = baseUrl
  }

  public verificarUsuario(usuario: Usuario): Observable<Usuario> {
        
    var body = {
      email: usuario.email,
      senha: usuario.senha
    }

    return this.http.post<Usuario>(this.baseUrl +"api/usuario/VerificarUsuario", body)
  }

  public usuarioAutenticado(): boolean {
    return this._usuario != null
        && this._usuario.email != ""
        && this._usuario.senha != "";
  }

  public limparSessao() {
    sessionStorage.setItem("usuario-autenticado", "");
    this._usuario = null;
  }

  public cadastrarUsuario(usuario: Usuario): Observable<Usuario>{
    var body = {
      email: usuario.email,
      senha: usuario.senha,
      nome: usuario.nome,
      sobrenome: usuario.sobrenome
    }

    return this.http.post<Usuario>(this.baseUrl + "api/usuario/cadastrarusuario", body)
  }

}
