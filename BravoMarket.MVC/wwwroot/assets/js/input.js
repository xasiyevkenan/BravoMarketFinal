const selectElement = document.getElementById('selection');

selectElement.addEventListener('change', (event) => {
    const selectedValue = event.target.value;

    if (selectedValue === '1') {
        selectElement.classList.remove('black');
    } else {
        selectElement.classList.add('black');
    }
});
