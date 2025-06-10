$(document).ready(function () {
    $(document).on('click', '#authorization-button', function () {

        var login = document.querySelector('#login-container').value;
        var password = document.querySelector('#password-container').value;

        $.ajax({
            url: '/Employee/Authorization',
            type: 'GET',
            contentType: 'application/json',
            data: { login: login, password: password },
            success: function (user) {
                console.log(`Вы авторизованы! Ваша роль: ${user.role}`);
                window.location.reload();
            },
            error: function () {
                alert('Данные неверны!');
            }
        });
    });


});