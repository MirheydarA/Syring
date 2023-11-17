﻿jQuery(function ($) {
    $(document).on('keyup', '#Name', function () {
        $.ajax({
            method: "GET",
            url: "/admin/product/filter",
            data: {
                title: $(this).val().trim()
            },
            success: function (result) {
                $('#table-body').html(result);
            },
            error: function (error) {
                alert(error)
            }
        })
    })
})