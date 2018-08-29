function exibirCarregando() {
	$body = $("body");
	$body.addClass("modal");
}

function ocultarCarregando() {
	$body = $("body");
	$body.removeClass("modal");
}

function numberToReal(numero) {
	numero = numero.toFixed(2).split('.');
	numero[0] = "R$ " + numero[0].split(/(?=(?:...)*$)/).join('.');
	return numero.join(',');
}