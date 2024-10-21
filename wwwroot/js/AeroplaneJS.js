$(document).ready(function () {
    GetAeroplanes();
});


/*Read Data*/
function GetAeroplanes() {
    $.ajax({
        url: '/aeroplanes/GetAeroplanes',
        type: 'get',
        datatype: 'json',
        contentType: 'application/json;charset=utf-8',
        success: function (response) {
            if (response == null || response == undefined || response.length == 0) {
                var object = '';
                object += '<tr>';
                object += '<td class="colspan="5">' + 'Aeroplanes not available ' + '</td>';
                object += '</tr>';
                $('#tblBody').html(object);
            }
            else {
                var object = '';
                $.each(response, function (index, item) {
                    object += '<tr>';
                    object += '<td>' + item.aeroplaneName + '</td>';
                    object += '<td>' + item.seatingCapacity + '</td>';
                    object += '<td>' + item.purchaseDate + '</td>';
                    object += '<td>' + item.price + '</td>'; console.log(item);
                    object += '<td>' + item.imageID + '</td>';
                    object += '<td>' + item.airlineCompanyId + '</td>';
                    object += '<td> <a href="#" class="btn btn-primary btn-sm" onclick="Edit(' + item.id + ')">Edit</a> <a href="#" class="btn btn-danger btn-sm" onclick="Delete(' + item.id + ')">Delete</a></td>';
                });

                $('#tblBody').html(object);

            }
        },
        error: function () {
            alert('Unable to read the data.');
        }
    });
}


$('#btnAdd').click(function () {
    $('#AeroplaneModal').modal('show');
    $('#modalTitle').text('Add Aeroplane');
});

/*Insert Data */
function Insert() {
    var result = Validate();
    if (result == false) {
        return false;
    }


    var formData = new Object();
    formData.id = $('#PlaneID').val();
    formData.id = $('#AeroplaneName').val();
    formData.id = $('#SeatingCapacity').val();
    formData.id = $('#AirlineCompany').val();
    formData.id = $('#PurchaseDate').val();
    formData.id = $('#Price').val();
    formData.id = $('#Image').val();

    $.ajax({
        url: '/aeroplanes/Insert',
        type: 'post',
        data: 'formData',
        success: function (response) {
            if (response == null || response == undefined || response.length == 0) {
                alert('Unable to save the data.');
            }
            else {
                HideModal();
                GetAeroplanes();
                alert(response);
            }

        },
        error: function () {
            alert('Unable to save the data.');
        }
    });
}

function HideModal() {
    $('#AeroplaneModal').modal('hide');
}

function clearData() {
    $('#AeroplaneName').val('');
    $('#SeatingCapacity').val('');
    $('#AirlineCompany').val('');
    $('#PurchaseDate').val('');
    $('#Price').val('');
    $('#Image').val('');
}


function Validate() {
    var isValid = true;

    if ($('#AeroplaneName').val().trim() == "") {
        $('#AeroplaneName').css('border-color', 'Red');
        isValid = false;

    }
    else {
        $('#AeroplaneName').css('border-color','lightgrey')
    }

    if ($('#SeatingCapacity').val().trim() == "") {
        $('#SeatingCapacity').css('border-color', 'Red');
        isValid = false;

    }
    else {
        $('#SeatingCapacity').css('border-color','lightgrey')
    }
    if ($('#PurchaseDate').val().trim() == "") {
        $('#PurchaseDate').css('border-color', 'Red');
        isValid = false;

    }
    else {
        $('#PurchaseDate').css('border-color','lightgrey')
    } if ($('#Price').val().trim() == "") {
        $('#Price').css('border-color', 'Red');
        isValid = false;

    }
    else {
        $('#Price').css('border-color','lightgrey')
    }
    
    if ($('#Image').val().trim() == "") {
        $('#Image').css('border-color', 'Red');
        isValid = false;

    }
    else {
        $('#Image').css('border-color','lightgrey')
    }
} 

$('#AeroplaneName').change(function () {
    Validate();
})
$('#SeatingCapacity').change(function () {
    Validate();
})
$('#PurchaseDate').change(function () {
    Validate();
})
$('#Price').change(function () {
    Validate();
})
$('#Image').change(function () {
    Validate();
})



/*Edit*/
function Edit(id) {

    $.ajax({
        url: '/aeroplanes/Edit?id='+id,
        type: 'get',
        contentType:'application/json;charset=utf-8',
        datatype: 'json',
        success: function (response) {
            if (response == null || response == undefined) {
                alert('Unable to read the data.');
            }
            else if (response.length == 0) {

                alert('Data not available with the id ' + id);
            }
            else {
                $('#AeroplaneModal').modal('show');
                $('#modalTitle').text('Update Aeroplane');
                $('#Save').css('display','none');
                $('#Update').css('display','block');
                $('#Id').val(response.id);
                $('#AeroplaneName').val(response.AeroplaneName);
                $('#SeatingCapacity').val(response.SeatingCapacity);
                $('#AirlineCompany').val(response.AirlineCompany);
                $('#PurchaseDate').val(response.PurchaseDate);
                $('#Price').val(response.Price);
                $('#Image').val(response.Image);
            }
                
            },

       
        error: function () {
            alert('Unable to read the data.');
        }
    });

}


/*Update Data*/
function Update() {
    var result = Validate();
    if (result == false) {
        return false;
    }
    var formData = new Object();

    var formData = new Object();
    formData.id = $('#PlaneID').val();
    formData.id = $('#AeroplaneName').val();
    formData.id = $('#SeatingCapacity').val();
    formData.id = $('#AirlineCompany').val();
    formData.id = $('#PurchaseDate').val();
    formData.id = $('#Price').val();
    formData.id = $('#Image').val();

    $.ajax({
        url: '/aeroplanes/Update',
        type: 'post',
        data: 'formData',
        success: function (response) {
            if (response == null || response == undefined || response.length == 0) {
                alert('Unable to save the data.');
            }
            else {
                HideModal();
                GetAeroplanes();
                alert(response);
            }

        },
        error: function () {
            alert('Unable to save the data.');
        }
    });


}


/*Delete Data*/
function Delete() {
    if (confirm('Arre you sure to delete this record ?')) {
        $.ajax({
            url: '/aeroplanes/Delete?id=' + id,
            type: 'post',
            success: function (response) {
                if (response == null || response == undefined) {
                    alert('Unable to delete the data.');
                }
                else {
                    GetAeroplanes();
                    alert(response);
                }
            },
            error: function () {
                alert('Unable to delete the data.');
            }
        }); }
    


}
