$(function () {
    $("#example1").DataTable({
        "responsive": true, "lengthChange": false, "autoWidth": false,
        "buttons": ["copy", "csv", "excel", "pdf", "print", "colvis"]
    }).buttons().container().appendTo('#example1_wrapper .col-md-6:eq(0)');
    $('#example2').DataTable({
        "paging": true,
        "lengthChange": false,
        "searching": false,
        "ordering": true,
        "info": true,
        "autoWidth": false,
        "responsive": true,
    });
});


$("select[class^='form-control ValidationType_").change(function () {
    //    console.log($(this).find(':selected').text());
    var validationNumber = $(this).find(':selected').val();
    var partialViewName;
    var partialViewName = "FormValidation/_" + $(this).find(':selected').text();
    var validationId = $(this).data("number");
    var url = $(this).data("url");
    console.log(url);
    $.ajax({
        tpye: "GET",
        url: url,
        data: { partialViewName: partialViewName, validationNumber: validationNumber }
    }).done(function (result) {
        console.log("stop");
        console.log(result);
        $(`.FormValidationRender_${validationId}`).empty().append(result);


    });
});



function cloneRow(test, cloneRow) {
    console.log(cloneRow);
    var rowCount = test - 1;
    var newRowCount = test + 1;
    var $tableBody = $('#example1').find("tbody"),
        $trLast = $tableBody.find(`tr:eq(${rowCount})`),
        $trNew = $trLast.clone();
    $trLast.after($trNew);
    $(`#example1 tr:eq(${newRowCount})`).attr('data-number', "0");
    $("select[class^='form-control ValidationType_").each(function (index) {
        index += 1;
        $(this).removeClass();
        $(this).addClass(`form-control ValidationType_${index}`);
        $(this).attr('data-number', index);
        $(`#example1 tr:eq(${index}) td:eq(6)`).removeClass();

        $(`#example1 tr:eq(${index}) td:eq(6)`).addClass(`FormValidationRender_${index}`);
    });


}


function SaveValidation() {
    var ValidationList = {
        validation: []
    };

    $('.clickable-row').each(function (index) {
        index += 1;
        var validationId = $(this).data("number");
        var FormValidations = {
            value: $(`#example1 tr:eq(${index}) td:eq(6)`).find('.validationErrorMessage').val(),
            QuestionId: $(`#example1 tr:eq(${index}) td:eq(3)`).data("number"),
            FormValidationTypeId: $(`select[class^='form-control ValidationType_${index}`).find(':selected').val(),
            FormId: $(`#example1 tr:eq(${index}) td:eq(1)`).data("number"),
            ErrorMessage: $(`#example1 tr:eq(${index}) td:eq(7)`).find('.form-control').val(),
            FormValidationSaveId: validationId
        };
        if ($(`select[class^='form-control ValidationType_${index}`).find(':selected').text() != "Selecteaza tipul de raspuns") {
            ValidationList.validation.push(FormValidations);
        }

    });

    $.ajax({
        type: "POST",
        url: "@Url.Action("ValidationFormSave")",
        data: { ValidationList: ValidationList }
    }).done(function (result) {
        console.log(result);

        toastr.success('Validarile au fost salvate.')

    });

    console.log(ValidationList);
}



