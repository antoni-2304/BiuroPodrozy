document.addEventListener('DOMContentLoaded', function () {
    var buttons = document.querySelectorAll('.fadeButton');

    buttons.forEach(function (button) {
        button.addEventListener('click', function () {
            var targetURL = button.getAttribute('data-target');
            fadeOutAndRedirect(button, targetURL);
        });
    });
});

function fadeOutAndRedirect(button, targetURL) {
    var fadeDirection = 'left';
    if (button.classList.contains('fadeButtonRight')) {
        fadeDirection = 'right';
    }

    var targetDiv = document.querySelector('.fadeCard');

    if (targetDiv) {
        if (fadeDirection === 'left') {
            targetDiv.classList.add('fade-out-left');
        } else if (fadeDirection === 'right') {
            targetDiv.classList.add('fade-out-right');
        }

        targetDiv.addEventListener('animationend', function () {
            window.location.href = targetURL;
        });
    }
}