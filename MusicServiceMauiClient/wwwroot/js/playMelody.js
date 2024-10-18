window.playMelody = (address, id) => {
    let url = `https://${address}/api/Melodies/${id}`;
    let player = $("#Player");

    $("#Player").on("timeupdate", function () {
        let playerElement = $(this)[0];
        let currentTime = playerElement.currentTime;
        let duration = playerElement.duration;

       
        let minutes = Math.floor(currentTime / 60);
        let seconds = Math.floor(currentTime % 60);
        let formattedTime = `${minutes}:${seconds < 10 ? '0' + seconds : seconds}`;
        $("#current-time-span").text(formattedTime);

        
        let seekbarValue = (currentTime / duration) * 100; 
        $("#seekbar").val(seekbarValue);
    });


    $("#seekbar").on("input", function () {
        let seekbarValue = $(this).val();
        let duration = player[0].duration;
        let newTime = (seekbarValue / 100) * duration;
        player[0].currentTime = newTime;
    });

    $(player).attr("src", url);
    $(".player-control-panel").css('visibility', 'visible');

    $(player).load();
    $(player).play();
}
