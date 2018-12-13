$(document).ready(function () {

    var nr = 2;


    $("#AddNewExerciseButton").click(function () {
        
        var url = "/Admin/GetExercisePartialView";

        $.ajax({
            data: { exerciseNr: nr },
            url: url,
            cache: false,
            type: "GET",
            success: function (result) {
                $('#ExerciseBoxList').append(result);
                /* little fade in effect */
                //$('#ExerciseBoxList').fadeIn('fast');

                nr = nr + 1;
            },
            error: function (reponse) {
                alert("error : " + reponse);
            }
        });

    });

});
