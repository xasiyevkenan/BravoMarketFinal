document.addEventListener('DOMContentLoaded', function () {
    const rangeSliders = document.querySelectorAll('input[type="range"]');
    const rangeValues = document.querySelector('.rangeValues');

    function filterProducts() {
        const minValue = parseFloat(rangeSliders[0].value);
        const maxValue = parseFloat(rangeSliders[1].value);

        const productPriceValues = document.querySelectorAll('.product_price_value');
        const products = document.querySelectorAll('.single_product');

        products.forEach((product, index) => {
            const productPrice = parseFloat(productPriceValues[index].textContent.replace("₼ ", ""));
            if (productPrice >= minValue && productPrice <= maxValue) {
                product.style.display = 'block'; 
            } else {
                product.style.display = 'none'; 
            }
        });
    }

    rangeSliders.forEach((slider) => {
        slider.addEventListener('input', filterProducts);
    });

    filterProducts();
});