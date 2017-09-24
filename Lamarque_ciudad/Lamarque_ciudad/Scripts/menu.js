$(document).ready(function(){
    var header = document.getElementById('header');
    var headroom = new Headroom(header);
    headroom.init();

    //menu responsive
    //calcular ancho
    var ancho = $(window).width(),
        enlaces = $("#enlaces"),
        btnMenu = $("#btn-menu"),
        icono = $("#btn-menu .icono");

    //Ocular
    If(ancho < 700);{
        enlaces.hide();
        icono.addClass("fa-bars");
    }

    btnMenu.on("click", function(e){
        enlaces.slideToggle();
        icono.toggleClass("fa-bars");
        icono.toggleClass("fa-times");
    });

    $(windows).on("resize", function(){
        if($(this).width()>700){
            enlaces.show();
            icono.addClass("fa-times");
            icono.removeClass("fa-bars");
        } 
        else {
            enlaces.hide();
            icono.addClass("fa-bars");
            icono.removeClass("fa-times");
        }
    });
});