$(document).ready(function () {
    $('#formValidation').submit(function (event) {
        var name = $('#Name').val();
        var description = $('#Description').val();
        var quantity = $('#Quantity').val();
        var price = $('#Price').val();

        if (name == "" || name.Length > 25) {
            $('#validationError').text("Name must be 25 characters or less.");
            $('#validationError').show();
            return false;
        }
        else if (description == "" || description.Length > 25) {
            $('#validationError').text("Description must be 25 characters or less.");
            $('#validationError').show();
            return false;
        }
        else if (quantity == "" || quantity < 0 || quantity > 500) {
            $('#validationError').text("Quantity must be between 0 and 500.");
            $('#validationError').show();
            return false;
        }
        else if (price == "" || price < 0 || price > 200) {
            $('#validationError').text("Price must be between 0 and 200.");
            $('#validationError').show();
            return false;
        }
        else {
            $('#validationError').hide();
        }
    });
});