//image preview function
function ShowPreview(input) {

    if (input.files && input.files[0]) {

        var reader = new FileReader();
        reader.onload = function (e) {
            $('#imgPreview').css('visibility', 'visible');
            $('#imgPreview').attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }

}

//Function will execute when the button "Click to Save" is clicked.
$(document).ready(function () {
    //datepicker
    $("#txtDateOfRegistration").datepicker();

    //Validation function
    $('#dateCheckError').hide();
    $('#companyNameError').hide();
  
    var dateOfRegistrationCheck = true;
    var companyNameCheck = true;
    var fileUploadCheck = true;

    //Company Name validation
    $('#txtCompnayName').keyup(function () {
        CompanyNameCheck();
    });
    
    function CompanyNameCheck() {
        var companyName = $('#txtCompnayName').val();
        if (companyName == '') {
            $('#companyNameError').show();
            $('#companyNameError').html("Please enter company name");
            $('#companyNameError').focus();
            $('#companyNameError').css("color", "red");
            companyNameCheck = false;
            return false;
        }
        else {
            $('#companyNameError').hide();
        }
    }

    //date of registration validation
    $('#txtDateOfRegistration').keyup(function () {
        DateOfRegistrationCheck();
    });

    function DateOfRegistrationCheck() {
        var dateOfRegistration = $('#txtDateOfRegistration').val();
        if (dateOfRegistration == '') {
            $('#dateCheckError').show();
            $('#dateCheckError').html("Please enter  registration date");
            $('#dateCheckError').focus();
            $('#dateCheckError').css("color", "red");
            dateOfRegistrationCheck = false;
            return false;
        }
        else {
            $('#dateCheckError').hide();
        }
    }

    //Onclick event on save button
    $('#btnSaveDetails').click(function () {
        dateOfRegistrationCheck = true;
        companyNameCheck = true;
        
        CompanyNameCheck();
        DateOfRegistrationCheck();

        if ((dateOfRegistrationCheck == true) && (companyNameCheck == true) ) {
             return true;
         }
        else
        {
             return false;
        }
    });
});