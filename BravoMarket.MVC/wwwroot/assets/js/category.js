const catalogMenuTab = document.getElementById('catalog-menu-tab');
const catalogs = document.getElementById('all_catalogs');
const catalogElements = document.querySelectorAll('.single_catalog');
let isMouseOverCatalogs = false;

catalogs.style.display = 'none';

function showCatalogs() {
    catalogs.style.display = 'block';
    catalogMenuTab.classList.add('hovered');
}

function hideCatalogs() {
    catalogs.style.display = 'none';
    catalogMenuTab.classList.remove('hovered');
}

function showSubTitle(subTitle) {
    subTitle.classList.add('show_sub_title');
}

function hideSubTitle(subTitle) {
    subTitle.classList.remove('show_sub_title');
}

catalogMenuTab.addEventListener('mouseover', () => {
    isMouseOverCatalogs = true;
    showCatalogs();
});

catalogs.addEventListener('mouseover', () => {
    isMouseOverCatalogs = true;
    showCatalogs();
});

catalogs.addEventListener('mouseout', () => {
    isMouseOverCatalogs = false;
    setTimeout(() => {
        if (!isMouseOverCatalogs) {
            hideCatalogs();
        }
    }, 400);
});

catalogElements.forEach((element) => {
    const subTitle = element.querySelector('.sub_title');

    element.addEventListener('mouseenter', () => {
        showSubTitle(subTitle);
    });

    element.addEventListener('mouseleave', () => {
        hideSubTitle(subTitle);
    });
});

catalogMenuTab.addEventListener('mouseleave', () => {
    isMouseOverCatalogs = false;
    setTimeout(() => {
        if (!isMouseOverCatalogs) {
            hideCatalogs();
        }
    }, 400);
});
