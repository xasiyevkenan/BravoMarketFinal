let input = document.querySelector('.responsive_header .search_input')
let icon = document.querySelector('.responsive_header .search_icon')
let search_icon = document.getElementById('product_search')

let catalogButtons = document.querySelectorAll('.ctlg');
let ctlgIcons = document.querySelectorAll('.ctlg_icon');
let subCategories = document.querySelectorAll('.sub_category');
let bar = document.querySelector('.hamburger_bar');
let close = document.querySelector('.close_ctlg');

search_icon.onclick = function(){
    input.classList.toggle('d-none')
    icon.classList.toggle('black')
}


for (let i = 0; i < ctlgIcons.length; i++) {
    ctlgIcons[i].onclick = function(e) {
        e.preventDefault();
        
        subCategories[i].classList.toggle('height');
        subCategories[i].classList.toggle('d-none');
        ctlgIcons[i].classList.toggle('hovered');
    }
}

bar.onclick = function(){
    document.body.classList.toggle('menu_open')
}

close.onclick = function(){
    document.body.classList.toggle('menu_open')
}