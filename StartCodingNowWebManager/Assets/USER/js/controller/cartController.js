var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {

        $('#btn_continue').on('click', function () {
            window.location.href = "/USER/Home/Index";
        });

        $('#btn_update').on('click', function () {
            
            var listproduct = $('input#txt_number');           
            var cartList = [];
            $.each(listproduct, function (i, item) {
                cartList.push({
                    Quantity: $(item).val(),
                    Product: {
                        IDRoBot: $(item).data('id')
                    }
                });
            });
            $.ajax({
                url: '/USER/Cart/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',

                success: function (res) {
                    console.log(res);
                    window.location.href = "/USER/Cart/Index";
                }

            });
        });
        $('#btn_delete').on('click', function () {
            $.ajax({
                url: '/USER/Cart/Delete',
                data: { id: $(this).data('id') },
                dataType: 'json',
                type: 'POST',

                success: function (res) {
                    console.log(res);
                    window.location.href = "/USER/Cart/Index";
                }

            });
        });
    }
};
cart.init();