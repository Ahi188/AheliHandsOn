// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

        //for hover table
    function openplace(evt, mallName) {
            var i, tabcontent, tablinks;
    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
            } //hidden tab contents
    tablinks = document.getElementsByClassName("tablinks");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active", "");
            }
    document.getElementById(mallName).style.display = "block";
    evt.currentTarget.className += " active";
        } //checking to see if it is matching with the button hovederd upon.

    //for slide show
    var slideIndex = 1;
    showSlides(slideIndex);

    // Next/previous controls
    function plusSlides(n) {
        showSlides(slideIndex += n);
        }

    // Thumbnail image controls
    function currentSlide(n) {
        showSlides(slideIndex = n);
        }

    function showSlides(n) {
            var i;
    var slides = document.getElementsByClassName("mySlides");
    var dots = document.getElementsByClassName("dot");
            if (n > slides.length) {slideIndex = 1}
    if (n < 1) {slideIndex = slides.length}
    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
            }
    for (i = 0; i < dots.length; i++) {
        dots[i].className = dots[i].className.replace(" active", "");
            }
    slides[slideIndex - 1].style.display = "block";
    dots[slideIndex - 1].className += " active";
        }
