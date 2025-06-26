$(document).ready(function () {
    if (!$.fn.DataTable.isDataTable('#dataTableTr')) {
        $('#dataTableTr').DataTable({
            language: {
                url: '//cdn.datatables.net/plug-ins/1.13.4/i18n/tr.json'
            }
        });
    }
});
    