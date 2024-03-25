let multipleCardCarouselRecommended = document.querySelector("#recommended-carousel");
let multipleCardCarouselCountries = document.querySelector("#recommended-countries-carousel");


let carouselWidthRecommended;
let carouselWidthCountries;

let cardWidthRecommended;
let cardWidthCountries;

let cardAmountRecommended;
let cardAmountCountries;

let scrollPositionRecommended;
let scrollPositionCountries;


document.addEventListener('DOMContentLoaded', function () {


    if (window.matchMedia("(min-width: 768px)").matches) {
        let carousel = new bootstrap.Carousel(multipleCardCarouselRecommended, {
            interval: false, // Disable automatic sliding
            wrap: false, // Prevent wrapping at the end
        });
        let carousel2 = new bootstrap.Carousel(multipleCardCarouselCountries, {
            interval: false, // Disable automatic sliding
            wrap: false, // Prevent wrapping at the end
        });


        carouselWidthRecommended = document.querySelector("#recommended-carousel .carousel-inner").scrollWidth;
        carouselWidthCountries = document.querySelector("#recommended-countries-carousel .carousel-inner").scrollWidth;

        cardWidthRecommended = document.querySelector("#recommended-carousel .carousel-item").offsetWidth;
        cardWidthCountries = document.querySelector("#recommended-countries-carousel .carousel-item").offsetWidth;

        cardAmountRecommended = 3;
        cardAmountCountries = 6;

        scrollPositionRecommended = 0;
        scrollPositionCountries = 0;


        document.querySelector("#recommended-carousel .carousel-control-next").addEventListener("click", function () {
            if (scrollPositionRecommended < carouselWidthRecommended - cardWidthRecommended * cardAmountRecommended) {
                scrollPositionRecommended += cardWidthRecommended;
                document.querySelector("#recommended-carousel .carousel-inner").scroll({ left: scrollPositionRecommended, behavior: 'smooth' });
            }
        });
        document.querySelector("#recommended-carousel .carousel-control-prev").addEventListener("click", function () {
            if (scrollPositionRecommended > 0) {
                scrollPositionRecommended -= cardWidthRecommended;
                document.querySelector("#recommended-carousel .carousel-inner").scroll({ left: scrollPositionRecommended, behavior: 'smooth' });
            }
        });

        document.querySelector("#recommended-countries-carousel .carousel-control-next").addEventListener("click", function () {
            if (scrollPositionCountries < carouselWidthCountries - cardWidthCountries * cardAmountCountries) {
                scrollPositionCountries += cardWidthCountries;
                document.querySelector("#recommended-countries-carousel .carousel-inner").scroll({ left: scrollPositionCountries, behavior: 'smooth' });
            }
        });
        document.querySelector("#recommended-countries-carousel .carousel-control-prev").addEventListener("click", function () {
            if (scrollPositionCountries > 0) {
                scrollPositionCountries -= cardWidthCountries;
                document.querySelector("#recommended-countries-carousel .carousel-inner").scroll({ left: scrollPositionCountries, behavior: 'smooth' });
            }
        });



    } else {
        multipleCardCarouselRecommended.classList.add("slide");  

        carouselWidthRecommended = document.querySelector("#recommended-carousel .carousel-inner").scrollWidth;
        carouselWidthCountries = document.querySelector("#recommended-countries-carousel .carousel-inner").scrollWidth;

        cardWidthRecommended = document.querySelector("#recommended-carousel .carousel-item").offsetWidth;
        cardWidthCountries = document.querySelector("#recommended-countries-carousel .carousel-item").offsetWidth;

        cardAmountRecommended = 3;
        cardAmountCountries = 2;

        scrollPositionRecommended = 0;
        scrollPositionCountries = 0;
        document.querySelector("#recommended-countries-carousel .carousel-control-next").addEventListener("click", function () {
            if (scrollPositionCountries < carouselWidthCountries - cardWidthCountries * cardAmountCountries) {
                scrollPositionCountries += cardWidthCountries;
                document.querySelector("#recommended-countries-carousel .carousel-inner").scroll({ left: scrollPositionCountries, behavior: 'smooth' });
            }
        });
        document.querySelector("#recommended-countries-carousel .carousel-control-prev").addEventListener("click", function () {
            if (scrollPositionCountries > 0) {
                scrollPositionCountries -= cardWidthCountries;
                document.querySelector("#recommended-countries-carousel .carousel-inner").scroll({ left: scrollPositionCountries, behavior: 'smooth' });
            }
        });
    }
});