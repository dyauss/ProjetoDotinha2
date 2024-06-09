// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let activeFilter = null;

function filterHeroes(attribute, imgElement) {

    document.querySelectorAll('.filter-img').forEach(img => img.classList.remove('active'));

    const isActive = imgElement.classList.contains('active');

    if (isActive || activeFilter === attribute) {
        imgElement.classList.remove('active');
        showAllHeroes();
        activeFilter = null;
    } else {
        imgElement.classList.add('active');
        activeFilter = attribute;
        const heroes = document.querySelectorAll('.card-heroes');
        heroes.forEach(hero => {
            if (hero.getAttribute('data-primary-attr') === attribute) {
                hero.style.display = 'block';
            } else {
                hero.style.display = 'none';
            }
        });
    }
}

function showAllHeroes() {
    const heroes = document.querySelectorAll('.card-heroes');
    heroes.forEach(hero => {
        hero.style.display = 'block';
    });
}