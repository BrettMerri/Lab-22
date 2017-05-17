$(document).ready(function () {
    $('#formValidation').submit(function (event) {
        var name = $('#Name').val();
        var description = $('#Description').val();
        var quantity = $('#Quantity').val();
        var price = $('#Price').val();
        var errorCount = 0;

        $('#validationError').empty();

        if (name == "" || description == "" || quantity == "" || price == "")
        {
            $('#validationError').append("<p>All fields are required</p>");
            return false;
        }

        if (name.length < 3 || name.length > 25) {
            $('#validationError').append("<p>Name must be between 3 and 25 characters.</p>");
            $('#validationError').show();
            errorCount++;
        }
        if (description.length < 3 || description.length > 25) {
            $('#validationError').append("<p>Description must be between 3 and 25 characters.</p>");
            $('#validationError').show();
            errorCount++;
        }
        if (quantity < 0 || quantity > 1000) {
            $('#validationError').append("<p>Quantity must be between 0 and 1000.</p>");
            $('#validationError').show();
            errorCount++;
        }
        if (price < 0 || price > 200) {
            $('#validationError').append("<p>Price must be between 0 and 200.</p>");
            $('#validationError').show();
            errorCount++;
        }
        if (errorCount > 0)
            return false;
        else {
            $('#validationError').hide();
        }
    });
});