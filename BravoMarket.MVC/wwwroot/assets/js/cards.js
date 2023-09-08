document.addEventListener('DOMContentLoaded', function () {
    const slider = document.querySelector('.s_slider');
    const dots = document.querySelectorAll('.owl-dot');
    
    let length = dots.length * 100;
    slider.style.width = `${length}%`;
    const slideWidth = 100/dots.length; 

    dots.forEach((dot, index) => {
        dot.addEventListener('click', function click() {

            const translationX = -index * slideWidth;

            slider.style.transform = `translateX(${translationX}%)`;

            dots.forEach((d) => d.classList.remove('active-dot'));
            dot.classList.add('active-dot');
        });
    });
});