
var picture = {
    List: []
};
$('.custom-select').on('change', function () {
    $('.DropDownScore').html('Puncte : ' + $(this).find(':selected').data('score')).removeAttr('style');
});



function clearSignature(clearSignatureHTMLId) {
    console.log(clearSignatureHTMLId);
    console.log('@Url.Action("RenderSignature")');
    $.ajax({
        type: "GET",
        url: "@Url.Action("RenderSignature")",
        data: { htmlId: clearSignatureHTMLId }
    }).done(function (result) {
       
        $(`#signature_${clearSignatureHTMLId}`).parent().parent().parent().html(result);
        var canvas = document.getElementById("signature_" + clearSignatureHTMLId + "");
        var signaturePad = new SignaturePad(canvas);
        $(`#signature_${clearSignatureHTMLId}`).on('click', function () {
            $(`input[name=${clearSignatureHTMLId}]`).val("DA");
        });
    });

}


$.each($("div[class^='signature_']"), function (index, value) {
    index = index + 1;
    var x = index;
    var sectionAndQuestion = $(this).find("canvas[id^='signature_']").data('nams');
    console.log($(this).find("canvas[id^='signature(']").data('nams'));
    jQuery(document).ready(function ($) {

        var canvas = document.getElementById("signature_" + sectionAndQuestion + "");
        var signaturePad = new SignaturePad(canvas);
        $(`#signature_${sectionAndQuestion}`).on('click', function () {
            $(`input[name=${sectionAndQuestion}]`).val("DA");
        });
    });

});

$("#addForm2").click(function () {
    console.clear();

    var form = {
        Name: $(".FormName").text(),
        Sections: []
    };

    var sectionOrder = 1;
    var sectionNumber = 0;
    $.each($("div[class^='row Section(']"), function (index, value) {
        sectionNumber++;
        var section = {
            Name: $(this).find('.SectionName').text(),
            SectionOrder: (++sectionOrder),
            Questions: []
        }
        var questionNumber = 0;
        $.each($(this).find("div[class^='card card-outline card-danger Question(']"), function (index2, value) {
            questionNumber++;
            var question = {
                Text: $(this).find('.text-xs-center').text(),
                QuestionType: $(this).find('.text-xs-center').data("name"),
                Answers: []
            };
            //    :$(this).find('input[name="section['+sectionNumber+']_question['+questionNumber+']"]').val()
            var answereNumber = 0;
            $.each($(this).find('div[class="custom-control answers"]'), function (index2, value) {
                console.log("da");
                answereNumber++;

                if ($(this).find('input[name="section_' + sectionNumber + '_question_' + questionNumber + '"]')) {
                    var Answer = {
                        Text: $(this).find('input[name="section_' + sectionNumber + '_question_' + questionNumber + '"]').val(),
                        Score: $(this).find('span[class="badge badge-success"]').text().replace('Puncte : ', '')
                    }
                }
                if ($(this).find('textarea[name="section_' + sectionNumber + '_question_' + questionNumber + '"]')[0]) {
                    var Answer = {
                        Text: $(this).find('textarea[name="section_' + sectionNumber + '_question_' + questionNumber + '"]').val(),
                        Score: $(this).find('span[class="badge badge-success"]').text().replace('Puncte : ', '')
                    }
                    question.Answers.push(Answer);
                }

                if ($(this).find('input[name="section_' + sectionNumber + '_question_' + questionNumber + '"]:checked').val() != null) {
                    question.Answers.push(Answer);
                }
                else {
                    if ($(this).find(".SingleDropDown")[0]) {
                        var Answer = {
                            Text: $(this).find('.SingleDropDown').find('.custom-select option:selected').val(),
                            Score: $(this).find('.SingleDropDown').find('.custom-select option:selected').data('score')
                        }
                        question.Answers.push(Answer);
                    }


                }

                if ($(this).find(".dropzone dz-clickable")) {
                    Object.keys(picture.List).forEach(function (key) {
                        var val = picture.List[key]["Section"];
                        var Pic = picture.List[key]["Picture"];

                        if (val == "section_" + sectionNumber + "_question_" + questionNumber + "") {
                            var Answer = {
                                Text: Pic
                            }
                            question.Answers.push(Answer);

                        }
                        document.getElementById('img').setAttribute('src', Pic);

                    });


                }
                if ($(this).find('div[class="SignatureInfo"]')[0]) {
                    var canvas = document.getElementById("signature_section_" + sectionNumber + "_question_" + questionNumber + "");
                    var Answer = {
                        Text: canvas.toDataURL()
                    }
                    question.Answers.push(Answer);
                }

                if ($(this).find(".AnswerNumber")[0]) {
                    var Answer = {
                        Text: $(this).find('input[name="section_' + sectionNumber + '_question_' + questionNumber + '"]').val(),
                        Score: $(this).find('span[class="badge badge-success"]').text().replace('Puncte : ', '')
                    }
                    question.Answers.push(Answer);
                }
                if ($(this).find(".dataAnswere")[0]) {
                    var Answer = {
                        Text: $(this).find('input[name="section_' + sectionNumber + '_question_' + questionNumber + '"]').val(),
                        Score: $(this).find('span[class="badge badge-success"]').text().replace('Puncte : ', '')
                    }
                    question.Answers.push(Answer);
                }


            });

            section.Questions.push(question);
        });
        form.Sections.push(section);
    });
    console.log(form);
});

Dropzone.autoDiscover = false;
$(".dropzone").dropzone({
    url: "/",
    uploadMultiple: false,
    autoProcessQueue: true,
    //acceptedFiles: "/*",
    init: function () {
        this.on("success", function (file) {
            var section = this.element.dataset['name'];
            //   $("#section_2_question_1+a").val("da");
            $(`input[name=${section}]`).val("DA");
            console.log(this);
            var reader = new FileReader();
            reader.onload = function (event) {
                var base64String = event.target.result;
                var fileName = file.name
                var Imagine = {
                    Section: section,
                    fileName: file.name,
                    Picture: base64String
                };
                picture.List.push(Imagine);
            };
            reader.readAsDataURL(file);

        });
    }

});





