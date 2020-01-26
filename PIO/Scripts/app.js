$(document).ready(function () {

    // question voting
    $(".question-vote-btn").on("click", function () {
        var button = $(this);
        $.ajax({
            url: "/api/vote/question/" + button.attr("data-question-id"),
            method: "GET",
            success: function (response) {
                if (response.VotedByUser) {
                    button.html("Глас -");
                    button.removeClass("btn-primary");
                    button.addClass("btn-danger");
                } else {
                    button.html("Глас +");
                    button.addClass("btn-primary");
                    button.removeClass("btn-danger");
                }
                button.siblings(".vote-count").html(response.VoteCount);
            },
            complete: function (xhr, textStatus) {
                if (xhr.status == 401) {
                    alert("Не сте најавени!");
                    return;
                }
            }
        });
    });

    // answer voting
    $(".answer-vote-btn").on("click", function () {
        var button = $(this);
        $.ajax({
            url: "/api/vote/answer/" + button.attr("data-answer-id"),
            method: "GET",
            success: function (response) {
                if (response.VotedByUser) {
                    button.html("Глас -");
                    button.removeClass("btn-primary");
                    button.addClass("btn-danger");
                } else {
                    button.html("Глас +");
                    button.addClass("btn-primary");
                    button.removeClass("btn-danger");
                }
                button.siblings(".vote-count").html(response.VoteCount);
            },
            complete: function (xhr, textStatus) {
                if (xhr.status == 401) {
                    alert("Не сте најавени!");
                    return;
                }
            }
        });
    });

    $(".delete-btn").on("click", function () {
        var button = $(this);
        if (confirm("Are you sure?")) {
            $.ajax({
                url: "/api/answers/deleteanswer/" + button.attr("button-answer-id"),
                method: "DELETE",
                success: function () {
                    button.parents(".question-list-item").remove();
                }
            });
        }
    });
});