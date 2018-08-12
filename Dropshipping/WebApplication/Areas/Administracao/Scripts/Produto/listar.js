$(document).ready(function () {
	$('#grid').DataTable({
		"order": [[1, "desc"]],
		"language": traducaoDatatable,
		dom: 'Bfrtip',
		buttons: [
		]
	});
});