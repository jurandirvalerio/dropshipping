$(document).ready(function () {
	$.ajax({
		type: "POST",
		url: serviceBaseUrl + "administracao/fornecedor/listarProdutos",
		success: function (data) {
			$('#grid').DataTable({
				"data": data,
				"columns": [
					{ "data": "Nome" },
					{ "data": "UrlEndpointApi", "title": "Endpoint da API" },
					{
						"data": "Codigo", "width": "100",
						"render": function (data, type, row, meta) {
							if (type === 'display') {
								data = '<a href="' + serviceBaseUrl + "administracao/fornecedor/estoque/" + data + '"><i class="fa fa-gift"></i>   Estoque</a>';
							}

							return data;
						}
					},
					{
						"data": "Codigo", "width": "100",
						"render": function (data, type, row, meta) {
							if (type === 'display') {
								data = '<a href="' + serviceBaseUrl + "administracao/fornecedor/alterar/" + data + '"><i class="fa fa-pencil-square-o"></i>   Alterar</a>';
							}

							return data;
						}
					}
				],
				"order": [[0, "desc"]],
				"language": traducaoDatatable,
				paginate: false,
				dom: 'Bfrtip',
				buttons: [{
						text: 'Incluir',
						action: function (e, dt, button, config) {
							window.location = serviceBaseUrl + "administracao/fornecedor/incluir";
						}
					}
				]
			});
		},
	});
});