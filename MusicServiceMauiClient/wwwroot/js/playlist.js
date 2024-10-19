let playlist = null

let previousMelody = null 
let currentMelody = null
let nextMelody = null

window.setPlaylist = (array, _id) => {
    playlist = array

    currentMelody = playlist.find(({id}) => id === _id)
}

window.getPrevious = () => {
    let indexOfCurrent = playlist.indexOf(currentMelody)

    console.log(currentMelody)

    previousMelody = playlist[--indexOfCurrent] !== undefined ? playlist[indexOfCurrent] : playlist[playlist.length-1]

    currentMelody = previousMelody
    console.log(currentMelody)

    return currentMelody
}

window.getCurrent = () => {
    return currentMelody
}

window.getNext = () => {
    let indexOfCurrent = playlist.indexOf(currentMelody)

    console.log(currentMelody)
    nextMelody = playlist[++indexOfCurrent] !== undefined ? playlist[indexOfCurrent] : playlist[0]

    currentMelody = nextMelody
    console.log(currentMelody)

    return currentMelody
}