const infoLinks = document.querySelectorAll('.info');

infoLinks.forEach(link => {
    link.addEventListener('click', (e) => {
        e.preventDefault(); 
        
        const parent = link.closest('.single_inf');
        const inner = parent.querySelector('.inner');
        const isOpen = parent.classList.contains('open');

        if (!isOpen) {
            link.classList.add('rotated'); 
            inner.style.height = inner.scrollHeight + 'px';
            parent.classList.add('open');
        } else {
            link.classList.remove('rotated'); 
            inner.style.height = '0';
            parent.classList.remove('open');
        }
    });
});
