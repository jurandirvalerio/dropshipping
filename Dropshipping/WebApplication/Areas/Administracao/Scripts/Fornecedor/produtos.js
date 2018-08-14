$(document).ready(function () {
	$.ajax({
		type: "POST",
		url: serviceBaseUrl + "administracao/fornecedor/listarProdutos?codigo=" + getParameterByName('codigo'),
		success: function (data) {
			$('#grid').DataTable({
				"data": data,
				"columns": [
					{ "data": "Nome" }, { "data": "Estoque" }, { "data": "Preco" }, { "data": "PrecoSugeridoVenda"}
				],
				"order": [[0, "desc"]],
				"language": traducaoDatatable,
				paginate: false,
			});
		},
	});
});