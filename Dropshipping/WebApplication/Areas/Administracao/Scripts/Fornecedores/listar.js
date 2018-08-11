$(document).ready(function () {

	$.ajax({
		type: "POST",
		url: serviceBaseUrl + "administracao/fornecedores/listar",
		success: function(data) {
			$('#grid').DataTable({
				"data": data,
				"columns": [
					{ "data": "Nome" },
					{ "data": "UrlEndpointApi", "title": "Endpoint da API" },
					{
						"data": "Codigo",
						"render": function (data, type, row, meta) {
							if (type === 'display') {
								data = '<a href="' + serviceBaseUrl + "administracao/fornecedores/alterar/" + data + '">Alterar</a>';
							}

							return data;
						}
					}
				],
				"order": [[1, "desc"]],
				"oLanguage": {
					"sInfo": "Mostrando do _START_ até _END_ de _TOTAL_ itens.",
					"sSearch": "Pesquisar"
				},
				dom: 'Bfrtip',
				buttons: [
					'csv', 'excel', 'pdf', {
						extend: 'print',
						text: 'Imprimir'
					}
				]
			});
		},
	});


	
});