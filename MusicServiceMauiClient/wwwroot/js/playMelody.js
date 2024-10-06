window.playMelody = (address, id) => {
    let url = `https://${address}/api/Melodies/${id}`
    let player = `<audio autoplay style="display: none" id="Player" type="audio/mp3" src='`
        + url + '/\' ></audio>'

    $("#audio-container").html(player)

    $("#Player").load()
    $("#Player").play()
    $("#state-pic").attr('src', '/img/pause.png')
}