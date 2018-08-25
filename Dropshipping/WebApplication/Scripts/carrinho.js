function getCarrinho() {
	return JSON.parse(localStorage.getItem("carrinho")) || [];
};

function setCarrinho(carrinho) {
	localStorage.setItem("carrinho", JSON.stringify(carrinho));
};

var getProdutoDoCarrinho = function(codigoProduto, carrinho) {
	var busca = carrinho.filter(e => e.Codigo === codigoProduto);
	if (busca.length === 1) {
		carrinho.pop(busca);
		return busca[0];
	}
	return { Codigo: codigoProduto, Quantidade: 0 };
};


var addProdutoNoCarrinho = function(codigoProduto) {
	var carrinho = getCarrinho();
	var produto = getProdutoDoCarrinho(codigoProduto, carrinho);
	produto.Quantidade = produto.Quantidade + 1;
	carrinho.push(produto);
	setCarrinho(carrinho);
	updateNumeroCarrinho();
};

var addCarrinho = function (e) {
	var codigoProduto = $(e.currentTarget).data('codigo');
	addProdutoNoCarrinho(codigoProduto);
};

Array.prototype.sum = function(prop) {
	var total = 0;
	for (var i = 0, _len = this.length; i < _len; i++) {
		total += this[i][prop];
	}
	return total;
};


var getTotalItensNoCarrinho = function() {
	return getCarrinho().sum("Quantidade");
};

var updateNumeroCarrinho = function () {
	var total = getTotalItensNoCarrinho();
	$('.numeroCarrinho').text(total > 0 ? total : '');
};

$(document).ready(function () {
	$('.addCarrinho').click(addCarrinho);
	updateNumeroCarrinho();
});