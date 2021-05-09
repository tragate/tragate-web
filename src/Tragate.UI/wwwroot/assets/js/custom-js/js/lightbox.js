$(function(){

  $("img.zoom").on("click",function(){
    var id = $(this).data("id");
    openModal();
    currentSlide(id);
  });

  $("a.prev").on("click",function(){
    plusSlides(-1);
  });

  $("a.next").on("click",function(){
    plusSlides(1);
  });

  $(document).keydown(function(e) {
    switch(e.which) {
        case 37: // left
          plusSlides(1);
        break;
        case 39: // right
          plusSlides(-1);
        break;
        default: return; // exit this handler for other keys
    }
    e.preventDefault(); // prevent the default action (scroll / move caret)
  });

  $(document).on('keyup',function(evt) {
    if (evt.keyCode == 27) //esc pressed
    {
      closeModal();
    }
  });

  $("#myModal").click(function(event) {
    if (!$(event.target).closest(".modal-content").length) {
      closeModal();
    }
  });
});

function openModal() {
  document.getElementById('myModal').style.display = "block";
}

function closeModal() {
  document.getElementById('myModal').style.display = "none";
}

var slideIndex = 1;

function plusSlides(n) {
  showSlides(slideIndex += n);
}

function currentSlide(n) {
  showSlides(slideIndex = n);
}

function showSlides(n) {
  var i;
  var slides = document.getElementsByClassName("mySlides");
  if (n > slides.length) {slideIndex = 1}
  if (n < 1) {slideIndex = slides.length}
  for (i = 0; i < slides.length; i++) {
      slides[i].style.display = "none";
  }
  
  slides[slideIndex-1].style.display = "block";
}