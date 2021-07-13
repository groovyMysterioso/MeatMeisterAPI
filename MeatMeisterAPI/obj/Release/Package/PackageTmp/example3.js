$(document).ready(function() {

    var columnDefs = [
        {
            data: "MeatOrderID",
            title: "MeatOrderID",
        type: "readonly"
        },
        {
        data: "OrderType",
        title: "Order Type"
        },
        {
            data: "CustomerName",
        title: "Customer Name"
        },
        {
            data: "CustomerPhoneNumber",
        title: "Phone Number"
        },
        
    ];

    var table = $('table').DataTable({
        "sPaginationType": "full_numbers",
        ajax: {
            url : "api/MeatOrders",
        },
        columns: columnDefs,
        dom: 'Bfrtip',        // Needs button container
        select: 'single',
        responsive: true,
        altEditor: true,     // Enable altEditor
        buttons: [
            {
                text: 'Add',
                name: 'add'        // do not change name
            },
            {
                extend: 'selected', // Bind to Selected row
                text: 'Edit',
                name: 'edit'        // do not change name
            },
            {
                extend: 'selected', // Bind to Selected row
                text: 'Delete',
                name: 'delete'      // do not change name
            },
            {
                text: 'Refresh',
                name: 'refresh'      // do not change name
            }
        ],
        onAddRow: function(datatable, rowdata, success, error) {
            console.log(rowdata);
            $.ajax({
                // a tipycal url would be / with type='PUT'
                url: "api/postMeatOrder",
                type: 'GET',
                data: rowdata,
                success: success,
                error: error
            });
        },
        onDeleteRow: function(datatable, rowdata, success, error) {
            $.ajax({
                // a tipycal url would be /{id} with type='DELETE'
                url: "api/deleteMeatOrder/{MeatOrderID}",
                type: 'GET',
                data: rowdata,
                success: success,
                error: error
            });
        },
        onEditRow: function(datatable, rowdata, success, error) {
            var util = {};
            util.post = function (url, fields) {
                var $form = $('<form>', {
                    action: url,
                    method: 'get'
                });
                $.each(fields, function (key, val) {
                    if (key != "undefined" && val!="")
                    $('<input>').attr({
                        type: "hidden",
                        name: key,
                        value: val
                    }).appendTo($form);
                });
                $form.appendTo('body').submit();
            }
            util.post('Order.htm', rowdata);
        }
    });


});

