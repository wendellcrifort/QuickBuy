import { Component } from "@angular/core"

@Component({
  selector: "produto",
  template: "<html><body>{{ obterNome() }}</body></html>"
})

export class ProdutoComponent {
  id: number;
  nome: string;
  descricao: string;
  preco: number;

  obterNome(): string {
    return "samsung"
  }
}
