let tabs = document.querySelectorAll('.tab');
let contentDivs = document.querySelectorAll('.contacts_form, .faq, .protection');

tabs.forEach((tab, index) => {
    tab.onclick = function (event) {

        event.preventDefault();

        tabs.forEach(tab => {
            tab.classList.remove('active_tab');
        });

        tab.classList.add('active_tab');

        contentDivs.forEach(div => {
            div.classList.add('d-none');
        });

        let tabIndex = parseInt(tab.getAttribute('data-index'));
        if (tabIndex === 1) {
            document.querySelector('.contacts_form').classList.remove('d-none');
        } else if (tabIndex === 2) {
            document.querySelector('.faq').classList.remove('d-none');
        } else if (tabIndex === 3) {
            document.querySelector('.protection').classList.remove('d-none');
        }
    };
});
