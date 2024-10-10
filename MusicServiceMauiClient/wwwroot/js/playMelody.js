window.playMelody = (address, id) => {
    let url = `https://${address}/api/Melodies/${id}`
    let player = `<audio autoplay style="display: none" id="Player" preload="metadata" type="audio/mp3" src='`
        + url + '/\' ></audio>'

    $(".player-control-panel").css('visibility', 'visible')
    $("#audio-container").html(player)

    $("#Player").load()
    $("#Player").play()
}