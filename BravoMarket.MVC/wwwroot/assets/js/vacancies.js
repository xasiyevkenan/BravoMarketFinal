document.addEventListener('DOMContentLoaded', function() {
    const tabLinks = document.querySelectorAll('.vacancies_tabs ul li a');
    const vacancySections = document.querySelectorAll('.vacancies');

    if (tabLinks.length > 0 && vacancySections.length > 0) {
        tabLinks[0].classList.add('active');
        vacancySections[0].classList.remove('d-none');

        tabLinks.forEach((tabLink, index) => {
            tabLink.addEventListener('click', (event) => {
                event.preventDefault();

                tabLinks.forEach((link) => {
                    link.classList.remove('active');
                });

                tabLink.classList.add('active');

                vacancySections.forEach((section) => {
                    section.classList.add('d-none');
                });

                vacancySections[index].classList.remove('d-none');
            });
        });
    }
});