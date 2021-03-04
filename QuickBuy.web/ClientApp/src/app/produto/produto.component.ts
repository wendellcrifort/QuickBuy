import { Component, OnInit } from "@angular/core"
import { Produto } from "../model/produto";
import { ProdutoServico } from "../servicos/produto/produto.servico"

@Component({
  selector: "app-produto",
  templateUrl: "./produto.component.html",
  styleUrls: ["./produto.component.css"]
})

export class ProdutoComponent implements OnInit {
  public produto: Produto;
    arquivoSelecionado: File;

  constructor(private produtoServico: ProdutoServico) {

  }
  ngOnInit(): void {
    this.produto = new Produto();
  }

  public cadastrar() {    
    this.produtoServico.cadastrar(this.produto)
      .subscribe(
        data => {
           
        }, err => {

        }) 
  }

  public salvar() {
    this.produtoServico.salvar(this.produto)
      .subscribe(
        data => {

        }, err => {

        })
  }

  public deletar() {
    this.produtoServico.deletar(this.produto)
      .subscribe(
        data => {

        }, err => {

        })
  }

  public obter() {
    this.produtoServico.listar()
      .subscribe(
        data => {

        }, err => {

        })
  }

  public inputChange(files: FileList) {
    this.arquivoSelecionado = files.item(0);
    this.produtoServico.enviarArquivo(this.arquivoSelecionado)
      .subscribe(
        data => {
          console.log(data)
        },
        err => {
          console.log(err)
        });
  }
}

