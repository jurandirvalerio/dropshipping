var traducaoDatatable = {
	"info": "Mostrando do _START_ até _END_ de _TOTAL_ itens.",
	"search": "Pesquisar",
	"emptyTable": "Sem dados para exibir",
	"zeroRecords": "Sem dados para exibir"
};

function getParameterByName(name, url) {
	if (!url) url = window.location.href;
	name = name.replace(/[\[\]]/g, '\\$&');
	var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
		results = regex.exec(url);
	if (!results) return null;
	if (!results[2]) return '';
	return decodeURIComponent(results[2].replace(/\+/g, ' '));
}