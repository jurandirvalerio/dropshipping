var vender = function(row) {

	$(".preloader").css('opacity', '0.5');
	$(".preloader").fadeIn();

	$(".preloader").css('opacity', '1');
	$(".preloader").fadeOut();
	//$.ajax({
	//	type: "POST",
	//	url: serviceBaseUrl + "administracao/produto/incluir",
	//	data: row,
	//	success: function(data) {
	//		$('#grid').DataTable({
	//			"data": data,
	//			"columns": [
	//				{ "data": "Nome" }, { "data": "Estoque" }, { "data": "Preco" }, { "data": "PrecoSugeridoVenda" },
	//				{
	//					"data": "VendidoNaLoja",
	//					"width": "150",
	//					"render": function(data, type, row, meta) {
	//						if (type === 'display') {
	//							if (data) {
	//								data = '<i class="fa fa-check-square-o"></i> Já vendendo';
	//							} else {
	//								data = '<a href="javascript:vender(row)"><i class="fa fa-plus-square-o"></i>   Passar a vender</a>';
	//							}
	//						}

	//						return data;
	//					}
	//				}
	//			],
	//			"order": [[0, "desc"]],
	//			"language": traducaoDatatable,
	//			paginate: false,
	//		});
	//	},
	//});
};

$(document).ready(function () {
	$.ajax({
		type: "POST",
		url: serviceBaseUrl + "administracao/fornecedor/listarProdutos?codigo=" + getParameterByName('codigo'),
		success: function (data) {
			$('#grid').DataTable({
				"data": data,
				"columns": [
					{ "data": "Nome" }, { "data": "Estoque" },
					{
						"data": "Preco", "render": function (data, type, row, meta) {
							if (type === 'display') {
								data = numberToReal(data);
							}
							return data;
						}
					},
					{
						"data": "PrecoSugeridoVenda", "render": function (data, type, row, meta) {
							if (type === 'display') {
								data = numberToReal(data);
							}
							return data;
						}
					},
					{
						"data": "VendidoNaLoja", "width": "150",
						"render": function (data, type, row, meta) {
							if (type === 'display') {
								if (data) {
									data = '<i class="fa fa-check-square-o"></i> Já vendendo';
								} else {
									data = '<a href="javascript:void(0)" onclick="vender(' + row.Guid + ')"><i class="fa fa-plus-square-o"></i>   Passar a vender</a>';
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
		},
	});
});

