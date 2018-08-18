var vender = function(row) {
	exibirCarregando();
	$.ajax({
		type: "POST",
		url: serviceBaseUrl + "administracao/produto/incluir",
		data: row,
		success: function (data) {
			location.reload();
			ocultarCarregando();
		}
	});
};

var carregarProdutos = function() {
	exibirCarregando();
	$.ajax({
		type: "POST",
		url: serviceBaseUrl + "administracao/fornecedor/listarProdutos?codigo=" + getParameterByName('codigo'),
		success: function(data) {
			$('#grid').DataTable({
				"data": data,
				"columns": [
					{ "data": "Nome" }, { "data": "Estoque" },
					{
						"data": "Preco",
						"render": function(data, type, row, meta) {
							if (type === 'display') {
								data = numberToReal(data);
							}
							return data;
						}
					},
					{
						"data": "PrecoSugeridoVenda",
						"render": function(data, type, row, meta) {
							if (type === 'display') {
								data = numberToReal(data);
							}
							return data;
						}
					},
					{
						"data": "VendidoNaLoja",
						"width": "150",
						"render": function(data, type, row, meta) {
							if (type === 'display') {
								if (data) {
									data = '<span class="vendendo"><i class="fa fa-check-square-o"></i> Já vendendo</span>';
								} else {
									data = '<a class="vender" href="javascript:void(0)" onclick="vender("' +
										row.Guid +
										'")"><i class="fa fa-plus-square-o"></i>   Passar a vender</a>';
								}
							}

							return data;
						}
					}
				],
				"order": [[0, "desc"]],
				"language": traducaoDatatable,
				paginate: false,
			});


			$('#grid tbody').on('click',
				'tr td .vender',
				function(e) {
					var table = $('#grid').DataTable();
					var data = table.row(this.parentElement.parentElement).data();
					vender(data);
				});
			ocultarCarregando();
		}
	});
};

$(document).ready(function () {
	carregarProdutos();
});