// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("#remove-btn").on("click", () => RemoveActiveProduct());
document.getElementById("edit-form").onsubmit = () => editProduct();

$(document).on("click", ".product-table-class tbody tr", function(event) {
    event.stopPropagation();
    event.stopImmediatePropagation();
    $(this).addClass('selected').siblings().removeClass('selected');
    var name=$(this).find('th').eq(1).html().toString();
    var description=$(this).find('th').eq(2).html().toString();
    var dbId=$(this).find('th').eq(3).html().toString();
    UpdateEditForm(name, description, dbId);
});

function UpdateEditForm(name, description, id) {
    $("#edit-form input[name='Name']").val(name);
    $("#edit-form input[name='ProductId']").val(id);
    $("#edit-form input[name='Description']").val(description);
}


function getActiveProductId() {
    var row = $(".product-table-class tbody").find(".selected")[0];
    if (row == undefined) {
        return -1;
    }

    var dbId=$(row).find('th').eq(3).html().toString();
    return dbId;
}


function editProduct() {
    var activeProductId = getActiveProductId();
    if (activeProductId == -1) {
        return;
    }

    console.log(activeProductId);
    var formData = new FormData(document.getElementById("edit-form"));
    fetch('edit', {
        method: 'put',
        body: new URLSearchParams(formData)
    })
    .then((result) => {
        return result.text();
    })
    .then ((data) => {
        $(".product-table-class").replaceWith(data);
    });

    return false;
}


function RemoveActiveTableItem() {
    $(".product-table-class tbody").find(".selected").remove();
}


function RemoveActiveProduct() {
    var activeProductId = getActiveProductId();
    if (activeProductId == -1) {
        return;
    }

    console.log(activeProductId);
    fetch(`remove/${activeProductId}`, {
        method: 'delete',
    })
    .then((result) => result.text())
    .then(() => {
        RemoveActiveTableItem();
    });
}


document.getElementById("add-form").onsubmit = () => {
    var formData = new FormData(document.getElementById("add-form"));
    fetch('add', {
        method: 'post',
        body: new URLSearchParams(formData)
    })
    .then((result) => {
        return result.text();
    })
    .then ((data) => {
        $(".product-table-class").replaceWith(data);
    });

    return false;
}
