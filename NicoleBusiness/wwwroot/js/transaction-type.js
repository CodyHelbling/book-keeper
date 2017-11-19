$(document).ready(function () {
    $.ajax({
        url: "/TransactionType/GetTransactionType",
        context: document.body
    }).done(function (types) {
        console.log("Move this code so it's only imported into Income and Expense entries!");
        var option = '';
        var row = '';
        var transactionTypes = types.object;
        for ( var i=0; i<transactionTypes.length; i++){
            option += '<option value="' + transactionTypes[i].id + '" class=' + '"dropdown-item">' + transactionTypes[i].name + ' </option>';
            row += '<tr><td>' + transactionTypes[i].id + '</td>' + '<td>' + transactionTypes[i].name + '<td>' + transactionTypes[i].description + '</td>'+ '<td><button type="button" class="btn btn-primary btn-sm btn-danger">Remove</button></td></tr>'; 
        }
        $('#transaction-type').append(option);
        $('#transaction-add-remove-table').append(row);
    });
});