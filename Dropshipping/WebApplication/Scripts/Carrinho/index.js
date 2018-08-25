var templateOriginal = '<tr><td><div class="media"><div class="d-flex"><img class="imagemItemCarrinho" src="[[IMAGEMITEMCARRINHO]]" alt=""></div><div class="media-body"><label class="nomeItemCarrinho">[[NOMEITEMCARRINHO]]</label></div></div></td><td><label>[[PRECOITEMCARRINHO]]</label></td><td><label>[[QUANTIDADEITEMCARRINHO]]</label></td><td><label>[[TOTALITEMCARRINHO]]</label></td><td><a class="removeCarrinho" data-codigo="[[CODIGO]]"><i class="fa fa-times" aria-hidden="true"></i></a></td></tr >';
var templateFooter = '<tr><td></td><td></td><td><h5>Subtotal</h5></td><td><h5 class="subtotalCarrinho">[[SUBTOTALCARRINHO]]</h5></td><td></td></tr><tr class="out_button_area"><td></td><td></td><td></td><td></td><td><div class="checkout_btn_inner"><a class="gray_btn" href="[[URLHOME]]">Continuar comprando</a><a class="main_btn" href="[[URLCHECKOUT]]">Fechar pedido</a></div></td></tr>';
$(document).ready(function () {

		exibirCarregando();

		var carrinho = getCarrinho();
		var produtos = carrinho.map(e => e.Codigo);
		var subtotal = 0;

	if (produtos.length > 0) {
		$.post(serviceBaseUrl + '/carrinho/obterProdutosCarrinho', { codigoProdutoSet: produtos }).done(function(data) {
			data.forEach(function (item) {
				$('.table').show();

				var template = templateOriginal;
				template = template.replace("[[IMAGEMITEMCARRINHO]]", item.UrlImagem);
				template = template.replace("[[NOMEITEMCARRINHO]]", item.Nome);
				var preco = item.Preco;
				template = template.replace("[[PRECOITEMCARRINHO]]", numberToReal(preco));
				var quantidade = getQuantidadePorProdutoDoCarrinho(item.Codigo, carrinho);
				template = template.replace("[[QUANTIDADEITEMCARRINHO]]", quantidade);
				var total = quantidade * preco;
				subtotal = subtotal + total;
				template = template.replace("[[TOTALITEMCARRINHO]]", numberToReal(total));
				template = template.replace("[[CODIGO]]", item.Codigo);

				$('.corpoTabelaCarrinho').append(template);
			});

			var template = templateFooter;
			template = template.replace("[[SUBTOTALCARRINHO]]", numberToReal(subtotal));
			template = template.replace("[[URLHOME]]", serviceBaseUrl);
			template = template.replace("[[URLCHECKOUT]]", serviceBaseUrl + '/pedido');
			$('.corpoTabelaCarrinho').append(template);
			ocultarCarregando();
		});
	} else {
		$('.table-responsive').html('<label style="text-align:center">Carrinho vazio</label>');
		ocultarCarregando();
	}
		
	$(document).on("click", "a.removeCarrinho", removeCarrinho);
	}
);