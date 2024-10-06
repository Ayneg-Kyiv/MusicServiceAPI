window.changeState = () => {

    if ($("#Player").prop('paused') == true) {
        $("#Player").trigger('play')
        $("#state-pic").attr('src', '/img/pause.png');
    }
    else {
        $("#Player").trigger('pause')
        $("#state-pic").attr('src', '/img/play.png');
    }
}