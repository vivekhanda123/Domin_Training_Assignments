document.addEventListener('DOMContentLoaded', function () {
    const form = document.querySelector('form');

    form.addEventListener('submit', function (e) {
        const firstName = document.getElementById('firstName').value;
        const email = document.getElementById('email').value;

        if (firstName === '' || email === '') {
            e.preventDefault();
            alert('Please fill out all required fields');
        }
    });
});
