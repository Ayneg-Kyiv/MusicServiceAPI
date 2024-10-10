window.updateProgress = () => {

    //$(".progress-bar")
    //$(".fill-bar")

    var songPlayer = document.getElementById("Player");
    console.log(songPlayer.duration)

    const pos = (songPlayer.currentTime / songPlayer.duration) * 100

    console.log(pos);

    //$(".target-time-span").html($("#Player").duration)
    //$("#state-pic").attr('src', '/img/pause.png')

    //$(".current-time-span")
    //$()
}