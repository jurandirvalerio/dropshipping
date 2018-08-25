function exibirCarregando() {
	$(".preloader").css('opacity', '0.5');
	$(".preloader").fadeIn();
}

function ocultarCarregando() {
	$(".preloader").css('opacity', '1');
	$(".preloader").fadeOut();
}

function numberToReal(numero) {
	numero = numero.toFixed(2).split('.');
	numero[0] = "R$ " + numero[0].split(/(?=(?:...)*$)/).join('.');
	return numero.join(',');
}