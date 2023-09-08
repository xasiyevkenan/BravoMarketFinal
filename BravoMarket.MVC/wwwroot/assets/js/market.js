document.addEventListener("DOMContentLoaded", function () {
    const marketLinks = document.querySelectorAll('.market_types a');
    const singleMarkets = document.querySelectorAll('.single_market');
    const searchInput = document.querySelector(".search_input input");
    let activeTab = 'active';

    marketLinks.forEach(link => {
        link.addEventListener('click', (event) => {
            event.preventDefault();

            marketLinks.forEach(link => {
                link.classList.remove('active');
            });

            link.classList.add('active');
            activeTab = link.classList[0];

            filterAndDisplayMarkets();
        });
    });

    searchInput.addEventListener("input", function () {
        filterAndDisplayMarkets();
    });

    searchInput.addEventListener("blur", function () {
        if (searchInput.value.trim() === "") {
            filterAndDisplayMarkets();
        }
    });

    function filterAndDisplayMarkets() {
        const searchText = searchInput.value.toLowerCase();

        singleMarkets.forEach(market => {
            const marketType = market.querySelector('.location span').innerText.toLowerCase();
            const shouldDisplayTab = activeTab === 'active' || activeTab.includes(marketType);
            const shouldDisplaySearch = market.querySelector(".single_market header h3")
                .textContent.toLowerCase().includes(searchText);

            const shouldDisplay = shouldDisplayTab && shouldDisplaySearch;

            market.style.display = shouldDisplay ? 'block' : 'none';
        });
    }

    filterAndDisplayMarkets();
});
