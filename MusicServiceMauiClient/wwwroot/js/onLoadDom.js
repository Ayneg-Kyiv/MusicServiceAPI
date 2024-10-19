window.onLoadAudio = () => {
    $("#Player").on("canplay", function () {
        const player = $(this)
        const playerElement = player[0]

        const duration = playerElement.duration

        const minute = Math.floor(duration / 60)
        const seconds = Math.floor(duration % 60)

        $("#target-time-span").html(`${minute}:${seconds < 10 ? '0' : seconds}`)

        $("#progress-bar").on("click", function (e) {
            let player = document.getElementById("progress-bar")

            const width = player.clientWidth
            const offset = e.offsetX

            playerElement.currentTime = (offset / width) * playerElement.duration
        })
    })

    $("#Player").on("timeupdate", function () {


        const player = $(this)
        const playerElement = player[0]

        const span = playerElement.currentTime
        const duration = playerElement.duration

        const minute = Math.floor(span / 60)
        const seconds = Math.floor(span % 60)

        $("#current-time-span").html(`${minute}:${seconds < 10 ? '0' + seconds : seconds}`)
        const position = (span / duration) * 100

        $(".fill-bar").css('width', `${position}%`)
    })

    $("#Player").on("ended", function () {
        const next = getNext()
        playMelody("00nz3bgf-7190.euw.devtunnels.ms", next)
    })
}