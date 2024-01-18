$(document).ready(function () {
    $('body').on('click', '#btnAddToCart', function (e) {
        e.preventDefault();
        var ProductId = $(this).data('id');
        var Quantity = 1;

        var Quantity = $("#quantity_value").text();
        if (Quantity == '') {
            Quantity = 1;
        } else {
            Quantity = parseInt(Quantity);
        }

        var data = { ProductId: ProductId, Quantity: Quantity }
        $.ajax({
            url: "/ShoppingCart/AddToCart",
            type: "POST",
            dataType: "JSON",
            data: data,
            success: function (rs) {
                console.log(rs);
                $("#checkout_items").html(rs.Count)
                alert(rs.meg);
            }
        })
    })
})



$(document).ready(function () {
    $("body").on("click", "#btnDelete", function (e) {
        e.preventDefault();
        var ProductId = $(this).data("id");
        var tr = $(this).parents("tr");
        var data = { ProductId: ProductId }
        var conf = confirm("Do you want delete this item?")
        if (conf == true) {
            $.ajax({
                url: "/ShoppingCart/RemoveItem",
                type: "POST",
                data: data,
                success: function (rs) {
                    $("#checkout_items").html(rs.Count)
                    tr.remove();
                    location.reload();
                }
            })
        }

    })
})


$(document).ready(function () {
    $("body").on("click", "#btnUpdate", function (e) {
        e.preventDefault();
        var ProductId = $(this).data("id");
        var tr = $(this).parents("tr");
        var Quantity = $("#QuantityOfProduct_" + ProductId).val();

        if (Quantity == '') {
            Quantity = 1;
        } else {
            Quantity = parseInt(Quantity);
        }
        var data = { ProductId: ProductId, Quantity: Quantity }
        $.ajax({
            url: "/ShoppingCart/Update",
            type: "POST",
            data: data,
            success: function (rs) {
                $("#checkout_items").html(rs.Count)
                location.reload();
            }
        })

    });

    $("body").on("click", "#btnDeleteAll", function (e) {
        e.preventDefault();
        var conf = confirm("Do you want delete all item?")
        if (conf == true) {
            $.ajax({
                url: "/ShoppingCart/DeleteAll",
                type: "POST",
                success: function (rs) {
                    $("#checkout_items").html(rs.Count)
                    location.reload();
                }
            })
        }

    });

    
})