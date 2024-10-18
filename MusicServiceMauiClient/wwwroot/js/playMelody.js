window.playMelody = (address, melody) => {
    let url = `https://${address}/api/Melodies/${melody.id}`
    let player = $("#Player")
    console.log(melody)

    setCurrent(melody)

    $(player).attr("src", url)

    $(".player-control-panel").css('visibility', 'visible')
    $("#state-pic").attr('src', '/img/pause.png');
    $(".melody-title").html(melody.title)
    $(".active-melody").attr('src', melody.imageUrl);

    $(player).load()
    $(player).play()
}