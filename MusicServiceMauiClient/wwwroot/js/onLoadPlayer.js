window.onLoadPlayer = () => {
    console.log('this')
    $(document).on("click", "#progress-bar", function (e) {
        console.log("123")
        let player = $("#Player")
        let playerElement = player[0]

        const width = $(this).clientWidth
        const offset = e.offsetX

        console.log(width)
        console.log(offset)

        playerElement.currentTime = (offset / width) * playerElement.duration
    })
}