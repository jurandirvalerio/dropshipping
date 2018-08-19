$(document).ready(function () {
	$.ajax({
		type: "POST",
		url: serviceBaseUrl + "administracao/produto/listarProdutos",
		success: function (data) {
			$('#grid').DataTable({
				"data": data,
				"columns": [
					{ "data": "Nome" },
					{
						"data": "PrecoCompra",
						"render": function (data, type, row, meta) {
							if (type === 'display') {
								data = numberToReal(data);
							}
							return data;
						}
					},
					{
						"data": "PrecoVenda",
						"render": function (data, type, row, meta) {
							if (type === 'display') {
								data = numberToReal(data);
							}
							return data;
						}
					},
					{ "data": "Fornecedor" },
					{
						"data": "Ativo" ,
						"render": function (data, type, row, meta) {
							if (type === 'display') {
								data = data === true ? "Sim" : "Não";
							}
							return data;
						}
					},
					{
						"data": "Codigo", "width": "100",
						"render": function (data, type, row, meta) {
							if (type === 'display') {
								data = '<a href="' + serviceBaseUrl + "administracao/produto/alterar/" + data + '"><i class="fa fa-pencil-square-o"></i>   Alterar</a>';
							}
							return data;
						}
					}
				],
				"order": [[0, "desc"]],
				"language": traducaoDatatable,
				paginate: false,
				dom: 'Bfrtip'
			});
		},
	});
});