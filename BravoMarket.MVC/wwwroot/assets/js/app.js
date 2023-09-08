document.addEventListener('DOMContentLoaded', function () {
    let bar_toggle = document.querySelector('.responsive_bar');
    let barmenu = document.querySelector('.bar_menu');

    if (bar_toggle) {
        bar_toggle.onclick = function () {
            bar_toggle.classList.toggle('active');
            bar_toggle.classList.toggle('active_second');

            if (bar_toggle.classList.contains('active')) {
                barmenu.style.left = '0';
                document.body.style.overflow = 'hidden'
            } else {
                barmenu.style.left = '100%';
                document.body.style.overflow = 'scroll'
            }
        };
    }
});

let navbars = document.querySelectorAll('.main_nav');


navbars.forEach((nav) => {
    nav.addEventListener('click', function() {
        console.log(nav);
        let activeNav = document.querySelector('.active_nav');
        if (activeNav) {
            activeNav.classList.remove('active_nav');
        }

        nav.classList.add('active_nav');
    });
});

