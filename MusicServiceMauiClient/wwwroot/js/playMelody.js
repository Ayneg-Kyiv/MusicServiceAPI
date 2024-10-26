window.playMelody = (address, melody) => {
    let url = `https://${address}/api/Melodies/${melody.id}`
    let player = $("#Player")
    
    $(player).attr("src", url)

    $(".player-control-panel").css('visibility', 'visible')
    $("#state-pic").attr('src', '/img/pause.png');
    $(".melody-title").html(melody.title)
    $(".author-name").html(melody.author.name)
    $(".active-melody").attr('src', melody.imageUrl);

    $(player).load()
    $(player).play()
}