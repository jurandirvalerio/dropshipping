$(document).ready(function () {
	$('#produtos').DataTable({
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
});