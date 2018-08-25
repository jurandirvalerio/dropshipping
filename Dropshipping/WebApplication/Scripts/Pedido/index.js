var templateOriginal = '<li><a>[[NOMEITEMCARRINHO]] ([[QUANTIDADEITEMCARRINHO]]) <span class="last"> [[TOTALITEMCARRINHO]]  </span></a></li>';
var templateFooter = '<li><a href="#">Total <span>[[SUBTOTALCARRINHO]]</span></a></li>';

$(document).ready(function () {

		exibirCarregando();

		var carrinho = getCarrinho();
		var produtos = carrinho.map(e => e.Codigo);
		var subtotal = 0;

	if (produtos.length > 0) {
		$.post(serviceBaseUrl + '/carrinho/obterProdutosCarrinho', { codigoProdutoSet: produtos }).done(function (data) {

			data.forEach(function (item) {
				$('.order_box').show();

				var template = templateOriginal;
				template = template.replace("[[NOMEITEMCARRINHO]]", item.Nome);
				var preco = item.Preco;
				var quantidade = getQuantidadePorProdutoDoCarrinho(item.Codigo, carrinho);
				template = template.replace("[[QUANTIDADEITEMCARRINHO]]", quantidade);
				var total = quantidade * preco;
				subtotal = subtotal + total;
				template = template.replace("[[TOTALITEMCARRINHO]]", numberToReal(total));
				template = template.replace("[[CODIGO]]", item.Codigo);

				$('#produtos').append(template);
			});

			var template = templateFooter;
			template = template.replace("[[SUBTOTALCARRINHO]]", numberToReal(subtotal));
			template = template.replace("[[URLHOME]]", serviceBaseUrl);
			template = template.replace("[[URLCHECKOUT]]", serviceBaseUrl + '/pedido');
			$('#subtotal').append(template);
			ocultarCarregando();
		});
	}
		
	$(document).on("click", "a.removeCarrinho", removeCarrinho);
	}
);