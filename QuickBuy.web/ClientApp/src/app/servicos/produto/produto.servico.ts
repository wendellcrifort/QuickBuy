import { Injectable, Inject, OnInit } from "@angular/core"
import { HttpClient, HttpHeaders } from "@angular/common/http"
import { Observable } from "rxjs"
import { Produto } from "../../model/produto";

@Injectable({
  providedIn: "root"
})

export class ProdutoServico implements OnInit {
  
  private _baseUrl: string;
  public produtos: Produto[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
  }
  ngOnInit(): void {
    this.produtos = [];
  }

  public cadastrar(produto: Produto): Observable<Produto> {
    var body = {
      nome: produto.nome,
      descricao: produto.descricao,
      preco: produto.preco
    }

    return this.http.post<Produto>(this._baseUrl + "api/produto/", body)
  }

  public salvar(produto: Produto): Observable<Produto> {
    var body = {
      nome: produto.nome,
      descricao: produto.descricao,
      preco: produto.preco
    }

    return this.http.post<Produto>(this._baseUrl + "api/produto/", body)
  }

  public deletar(produto: Produto): Observable<Produto> {
    var body = {
      nome: produto.nome,
      descricao: produto.descricao,
      preco: produto.preco
    }

    return this.http.post<Produto>(this._baseUrl + "api/produto/", body)
  }

  public listar(): Observable<Produto[]> {
    return this.http.get<Produto[]>(this._baseUrl + "api/produto/")
  }

  public enviarArquivo(arquivoSelecionado: File): Observable<boolean> {
    const formData: FormData = new FormData();

    formData.append("arquivoSelecionado", arquivoSelecionado, arquivoSelecionado.name)

    return this.http.post<boolean>(this._baseUrl + "api/produto/enviarArquivo", formData);
  }

}
