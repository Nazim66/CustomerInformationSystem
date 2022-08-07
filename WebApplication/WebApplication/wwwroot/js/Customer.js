$(document).ready(function () {
    loadDataTable();
    $('#btnUpdate').hide();
});


function SaveCustomerInfo(){
    debugger;
    var data = getData();

    $.ajax({
        url: '/Customer/AddCustomer',
        data: { "prm": data },
        type: "POST",
        dataType: "json",
        async: true,
        success: function (result) {
            alert('Successfully Added to the Database');
            closePopup();
            $('#tblData').DataTable().ajax.reload();   
        },
        error: function () {
            alert('Failed to receive the Data');
        }
    });
}


function UpdateCustomerInfo() {

    var data = getData();
    $.ajax({
        url: '/Customer/UpdateCustomer',
        data: { "prm": data },
        type: "POST",
        dataType: "json",
        async: true,
        success: function (result) {
            alert('Update Successfully done!');
            closePopup();
            $('#tblData').DataTable().ajax.reload();
        },
        error: function () {
            alert('Failed to receive the Data');
        }
    });
}


function getData() {
    object = new Object();
    object.CustomerId = $("#customerId").val();
    object.Sex = $('#ddlSex option:selected').val();
    object.Name = $("#customerName").val();
    object.Phone = $("#phone").val();
    object.LandPhone = $("#landPhone").val();
    object.PostCode = $("#postCode").val();
    object.PostOffice = $("#postOffice").val();
    object.Thana = $("#thana").val();
    object.Zilla = $("#zilla").val();
    object.Address = $("#address1").val();
    object.PermanentAddress = $("#pAddress").val();
    object.Remarks = $("#remarks").val();
    object.Discount = $("#discount").val();

    return object;
}


function loadDataTable() {

    $('#tblData thead th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" style= width:100% placeholder="' + title + '"/>');
    });

    var table = $('#tblData').DataTable({
        "ajax": {
            "url": "Customer/GetAll",
            "dataSrc": '',
        },
        searchPanes: {
            viewTotal: true
        },
        dom: 'Bfrtip',
        select: true,
        "createdRow": function (row, data, dataIndex) {
            if (data.status == true) {
                $(row).css('color', 'red');
            }
        },
        "columns": [
            { "data": "customerId", "width": "15%" },
            { "data": "name", "width": "15%"},
            { "data": "phone", "width": "15%"},
            { "data": "discount", "width": "15%" },
            { "data": "sex", "width": "15%" },
            { "data": "remarks", "width": "15%" },
            {
                "data": "customerId",                
                "render": function (data) {
                    return `
                            <div class="text-center">
                                  <input type="file" name="import_file" onchange=UploadImage("/Customer/UploadImage/${data}"/>
                                <a style="color:black" onclick=GenerateSingleInfo("/Customer/GetById/${data}") >
                                    <i class="fas fa-edit"></i>
                                </a>
                                <a style="color:black" id="btnDelete" onclick=UpdateStatusForDelete("/Customer/UpdateStatus/${data}")>
                                    <i class="fa fa-trash"></i>
                                </a>
                           </div>`;

                }, "width": "20%"
            }
        ]
    });
    table.columns().every(function () {
        var that = this;

        $('input', this.header()).on('keyup change', function () {
            if (that.search() !== this.value) {
                that
                    .search(this.value)
                    .draw();
            }
        });
    });
}


function UploadImage(url) {
    $.ajax({
        type: "GET",
        url: url,
        success: function (data) {
            $('#tblData').DataTable().ajax.reload();
        },
        error: function (xhr) {
            alert(xhr.responseText);
        }
    });


}

function UpdateStatusForDelete(url) {
    $.ajax({
        type: "GET",
        url: url,
        success: function (data) {
            alert("Successfully Deleted!");
            $('#tblData').DataTable().ajax.reload();
            $('#btnDelete').prop('disabled', true);
        },
        error: function (xhr) {
            alert(xhr.responseText);
        }
    });
}

$(function () {
    $('#btnclick').click(function () {
        setTimeout(function() {
            ClearAll();
            $('#btnUpdate').hide();
            $('#btnSave').show();
            $("#customerId").prop('disabled', false);
        }, 50);
        $("#popupdiv").dialog({
            title: "Add New Customer",
            width: 700,
            height: 550,
            modal: true,
        });
    });
})

function closePopup() {
        $("#popupdiv").dialog('close');
}


function GenerateSingleInfo(url) {
    $('#btnUpdate').show();
    $('#btnSave').hide();

    $.ajax({
        type: "GET",
        url: url,
        success: function (data) {
            PopulateInfo(data);
        },
        error: function (xhr) {
            alert(xhr.responseText);
        }
    });
}

function PopulateInfo(data) {

    $("#popupdiv").dialog({
        title: "Add New Customer",
        width: 700,
        height: 550,
        modal: true,
    });
    $("#popupdiv").dialog('open');
    $("#customerId").val(data.customerId);
    $("#customerId").prop('disabled', true);
    if (data.sex == 1) {
        $('#ddlSex').val(1);
    }
    if(data.sex == 2) {
        $('#ddlSex').val(2);
    }
    $("#customerName").val(data.name);
    $("#phone").val(data.phone);
    $("#landPhone").val(data.landPhone);
    $("#postCode").val(data.postCode);
    $("#postOffice").val(data.postOffice);
    $("#thana").val(data.thana);
    $("#zilla").val(data.zilla);
    $("#address1").val(data.address);
    $("#pAddress").val(data.permanentAddress);
    $("#remarks").val(data.remarks);
    $("#discount").val(data.discount);
}

function ClearAll() {

    $("#popupdiv").dialog('open');
    $("#customerId").val("");

    $('#ddlSex').val(0);
  
    $("#customerName").val("");
    $("#phone").val("");
    $("#landPhone").val("");
    $("#postCode").val("");
    $("#postOffice").val("");
    $("#thana").val("");
    $("#zilla").val("");
    $("#address1").val("");
    $("#pAddress").val("");
    $("#remarks").val("");
    $("#discount").val("");
}