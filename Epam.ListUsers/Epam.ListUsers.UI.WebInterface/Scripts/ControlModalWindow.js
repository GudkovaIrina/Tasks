$actionDelete = $(".delete");
$actionDelete.on("click", del)

function del(e) {
    var $message = $(".modal-body h3");
    $message.text($(e.target).attr("data-message"));
    $('.lu-modal').modal();
    $buttonOk = $("#btnOk");
    id = $(e.target).attr("data-id");
    idUser = $(e.target).attr("data-id-user");
    idAward = $(e.target).attr("data-id-award");
    $buttonOk.on("click", { id: id, idUser: idUser, idAward: idAward }, subm)
}

function subm(e) {
    var form = document.forms.id,
        input = form.elements.id,
        idUser = form.elements.idUser,
        idAward = form.elements.idAward;
    if (input) {
        input.value = e.data.id;
    }

    if (idUser) {
        idUser.value = e.data.idUser;
    }

    if (idAward) {
        idAward.value = e.data.idAward;
    }

    form.submit();
}