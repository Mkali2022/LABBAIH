//$(document).ready(function () {
//    $('#CompanyCat').dataTable({
//        "serverSide": true,
//        "filter": true,
//        "ajax": {
//            "url": "/api/GetAllCategoryCom",
//            "type": "POST",
//            "datatype":"json"
//        },
//        "columnDefs": [{
//            "targets": [0],
//            "visible": false,
//            "searchable": false

//        }],
//        "columns": [
//            { "data": "id", "name": "ID", "autowidth": true },
//            { "data": "code", "name": "Code", "autowidth": true },
//            { "data": "comType", "name": "CompaniesType", "autowidth": true },
//            {
//                "render": function (data, type, row) { return '<a href="#" class="btn btn-danger" onclick=Delete("' + row.id + '");> Delete </a>' }
//                "orderable": false
//            },

//        ]
//    })
//});
@section Secripts{
    <script>
        $(".form-group")
    </script>
}