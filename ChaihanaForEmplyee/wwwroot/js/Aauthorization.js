$(document).ready(function () {
    $(document).on('click', '#authorization-button', function () {

        var login = document.querySelector('#login-container').value;
        var password = document.querySelector('#password-container').value;

        $.ajax({
            url: '/Employee/Api/Authorization',
            type: 'GET',
            contentType: 'application/json',
            data: { login: login, password: password },
            /*success: function (user, data) {
                console.log(`Вы авторизованы! Ваша роль: ${user.role}`);
                *//*window.location.reload();*//*
                window.location.href = response.url
            },*/
            success: function (response) {
                if (response.redirectUrl) {
                    window.location.href = response.redirectUrl; // Редирект
                } else {
                    console.log("Успешная авторизация", response);
                }
            },
            error: function () {
                alert('Данные неверны!');
            }
        });
    });


});