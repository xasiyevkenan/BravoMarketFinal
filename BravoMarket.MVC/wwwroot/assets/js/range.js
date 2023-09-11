function getVals() {
    var parent = this.parentNode;
    var slides = parent.getElementsByTagName("input");
    var slide1 = parseFloat(slides[0].value);
    var slide2 = parseFloat(slides[1].value);

    if (slide1 > slide2) {
        var tmp = slide2;
        slide2 = slide1;
        slide1 = tmp;
    }

    var displayElement = parent.getElementsByClassName("rangeValues")[0];
    if ((slide1 == 1 && slide2 == 1) || (slide1 == 2 && slide2 == 2)) {
        displayElement.innerHTML = "₼ " + slide1.toFixed(2) + " - ₼ " + slide2.toFixed(2) + " ";
    } else {
        displayElement.innerHTML = "₼ " + slide1.toFixed(1) + " - ₼ " + slide2.toFixed(1) + " ";
    }
}

window.onload = function () {
    var sliderSections = document.getElementsByClassName("range-slider");
    for (var x = 0; x < sliderSections.length; x++) {
        var sliders = sliderSections[x].getElementsByTagName("input");
        for (var y = 0; y < sliders.length; y++) {
            if (sliders[y].type === "range") {
                sliders[y].addEventListener('input', getVals);
                getVals.call(sliders[y]);
            }
        }
    }
};

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