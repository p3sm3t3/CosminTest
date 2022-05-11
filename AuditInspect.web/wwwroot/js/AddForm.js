

    $("#formName").on('input', function() {
        $("#addNewFormSection").show();
        });

        var firstClick = true;
        var sectionNumber = 0;
        $("#addNewFormSection").click(function(){
        $.ajax({
            type: "GET",
            url: $(this).data("url"),
            data: { sectionNumber: (++sectionNumber) }
        }).done(function (result) {
            $("#formSections").append(result);
        });
        });

        var questionNumber = 0;

        function addNewFormQuestion(sectionNumberForThisQuestion,url,textInfo){
        $.ajax({
            type: "GET",
            url: url,
            data: { questionNumber: (++questionNumber) }
        }).done(function (result) {
            var textResult = result.replace(textInfo, "");
            if (textInfo !== 'Intrebare logica') {
                textResult = textResult.replace("show","hide")
            }
            console.log(textResult);
            $(`.questions_${sectionNumberForThisQuestion}`).append(textResult);
            $("#addForm").show();
        });
        }

        function selectAQuestionType(input,questionNumber)
        {
            var selectedQuestionType = input.value;
            var url = $("#answareUrl").val();
            var partialViewName = "";

            switch (selectedQuestionType) {
	                case '1':
		                partialViewName = "_QuestionTypeCheckbox";
		                break;
	                case '2':
		                partialViewName = "_QuestionTypeRadio";
		                break;
	                  case '3':
		                partialViewName = "_QuestionTypeDropDown";
		                break;
                    case '4':
		                partialViewName = "_QuestionTypeFileUpload";
		                break;
                    case '5':
		                partialViewName = "_QuestionTypeText";
		                break;
                    case '6':
		                partialViewName = "_QuestionTypeNumber";
		                break;
                    case '10':
		                partialViewName = "_QuestionTypeDateTime";
		                break;
                    case '12':
		                partialViewName = "_QuestionTypeSignature";
		                break;
	                default:
		                alert('Nu este implementat!');
            }

            $.ajax({
        tpye:"GET",
                url: url,
                data: {partialViewName: partialViewName, questionNumber: questionNumber }
                }).done(function(result){
                 $(`.answaresForQuestion_${questionNumber}`).empty();
               $(`.answaresForQuestion_${questionNumber}`).append(result);
               if (selectedQuestionType == 12){
                     jQuery(document).ready(function ($) {
                          var canvas = document.getElementById("signature");
                             var signaturePad = new SignaturePad(canvas);
                            $('#clear-signature').on('click', function () {
                                signaturePad.clear();
                            });
                    });
               }
            })
        }


        function addNewCheckboxOption(questionNumber){
        $(`.optionsForCheckbox_${questionNumber}`).append($(".checkboxAnswareRow").html());
        }
          function addNewRadioOption(questionNumber){
        $(`.optionsForRadio_${questionNumber}`).append($(".radioAnswareRow").html());
        }

          function addNewDropDownOption(questionNumber){
        $(`.optionsForDropDown_${questionNumber}`).append($(".dropDownAnswareRow").html());
        }
        function addNewFileUploadOption(questionNumber){
        $(`.optionsForFileUpload_${questionNumber}`).append($(".fileUploadAnswareRow").html());
        }

        function addNewTextOption(questionNumber){
        $(`.optionsForText_${questionNumber}`).append($(".textAnswareRow").html());
        }
        function addNewNumberOption(questionNumber){
        $(`.optionsForNumber_${questionNumber}`).append($(".numberAnswareRow").html());
        }

        function addNewDateTimeOption(questionNumber){
        $(`.optionsForDateTime_${questionNumber}`).append($(".dateTimeAnswareRow").html());
        }

        $("#addForm").click(function() {
            var form = {
        Name: $("#formName").val(),
                Departament: $('#DepartamentID option:selected').val(),
                Sections: []
            };
            var sectionOrder = 1;
            var AnswerNumber = 0;

            $.each($("div[class^='formSectionID_']"), function(index, value) {
                    var section = {
        Name: $(this).find('#SectionName').val(),
                        SectionOrder: (++sectionOrder),
                        Questions: []
                    };
                    if (index === 0) return;
                    $.each($(`.questions_${index}`).find(".timeline-item"), function(index2, value) {
                        var question = {
        Text: $(this).find("input[id^='QuestionName_']").val(),
                            QuestionType: $(this).find('.questionTypeInt').val(),
                            QuestionDisplay: $(this).find('.questionTypeInfo').data("name"),
                            Answers: []
                        };
                        $.each($(this).find("section[class^='answaresForQuestion_").find("div[class^='row"), function(index4, value4) {
                            var answer = {
        Text: $(this).find("input[id^='QuestionResponse']").val(),
                                Score: $(this).find("input[id^='QuestionScore']").val()
                            };
                            question.Answers.push(answer);
                        });

                        section.Questions.push(question);


                    });
                    form.Sections.push(section);

            });
            console.log(form);


             $.ajax({
                type:"POST",
                url: $(this).data("url"),
                data: {form :form}
                }).done(function(result){
        window.location.href = "/Dashboard/Form/Index"; //TODO: cu link construit din razor din data-attr
                });
        });
   