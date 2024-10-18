let playlist = []

let previousMelody = null 
let currentMelody = null
let nextMelody = null

const setPlaylist = (array) => {
    playlist = array
}
const setPrevios = (melody) => {
    previousMelody = melody
}
const setCurrent = (melody) => {
    currentMelody = melody
    console.log(currentMelody)
}
const setNext = (melody) => {
    nextMelody = melody
}