
  
  $(document).ready(function () {

    
    $('.zoom')
    // tile mouse actions
    .on('mouseover', function(){
      $(this).css({'transform': 'scale('+ $(this).attr('data-scale') +')'});
    })
    .on('mouseout', function(){
      $(this).css({'transform': 'scale(1)'});
    })
    .on('mousemove', function(e){
      $(this).css("cursor","zoom-in");
      $(this).css({'transform-origin': ((e.pageX - $(this).offset().left) / $(this).width()) * 100 + '% ' + ((e.pageY - $(this).offset().top) / $(this).height()) * 100 +'%'});
    });
    // tiles set up
  
  });
  