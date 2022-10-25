$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: 'https://localhost:44377/api/patient/Getdoctornamelist',
        data: {
            doctorname: $('#txtdoctorname').val(),
        },
        success: function (data) {
            let s = '<option value="-1">Please Select an DoctorName</option>';
            for (let i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].ID + '">'+ data[i].doctorName + '</option>';
            }
            $("#txtdoctorname").html(s);
        },
        error: function(){
            alert("error occured");
        }
    });
});
$(document).ready(function () {
    $.ajax({
        url: 'https://localhost:44377/api/patient/Getspecialist',
        method: "GET",

        data: {
            specialist: $('#txtspecialist').val(),
        },
        success: function (data) {
            let s = '<option value="-1">Please Select an Specialist</option>';
            for (let i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].DID + '">' + data[i].specialist + '</option>';
            }
            $("#txtspecialist").html(s);
        },
        error: function () {
            alert("error occured");
        }
    });
});
$('#appointment').click(function () {
    $.ajax({
        url: 'https://localhost:44377/api/patient/AddAppointment',
        method: "POST",
        data: {
           doctorname : $('#txtdoctorname').val(),
            specialist: $('#txtspecialist').val(),
            Date: $('#txtdate').val()

        },
        success: function () {
            alert("appointment booked")

        },
        error: function () {
        }
    })
})

