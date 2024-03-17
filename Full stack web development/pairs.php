

<!DOCTYPE html>
<html>
<head>
<title>Pairs Memory Game</title>
<style>
#board {
width: 600px;
height: 600px;
background-color: grey;
box-shadow: 5px 5px 5px black;
margin: auto;
margin-top: 50px;
display:grid;
grid-template-columns: repeat (auto-fill, minmax(120px, 1fr));
grid-gap: 10px;
justify-items: center;
align-items: center;
}
.start-button {
margin: auto;
display:block;
}
.submit-score{
margin: auto;
display:block;
}
.card {
position: relative;
width: 80px;
height: 80px;
margin: 10px;
border-radius: 5px;
background-color: #fff;
box-shadow: 2px 2px 5px rgba(0,0,0,0.2);
transform-style:preserve-3d;
transition: all 0.5s ease-in-out;
}
.card .back {
position: absolute;
top: 0;
left: 0;
width: 80px;
height: 80px;
border-radius: 5px;
background-color: #333;
backface-visibility:hidden;
}

.card .front { 
position: absolute;
 top: 0;
left: 0; width: 100%; height: 100%; border-radius: 5px; font-size: 60px; color: #333;
background-position: center; background-repeat: no-repeat;
text-align: center;
line-height: 80px;
transform: rotateY(180deg);
}
.card.flipped{

transform: rotateY(180deg);
}



.card img {
width: 100%;
height: 100%;
object-fit: contain;
}
#main {
position: absolute;
top: 50%;
left: 50%;
transform: translate(-50%, -50%);
 width: 100%;
height: 100%;
background:url('https://images.unsplash.com/photo-1511512578047-dfb367046420?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1742&q=80');
background-size:cover;
background-position: center center;
text-align:center;
color:white;
}
</style>
</head>a
<body>
<div id="main">


<?php
session_start();
if (isset($_SESSION['username'])) {
// User is logged in, display the welcome message and "Click here to play" button
$username = $_SESSION['username'];
$session = True;
$button_text = "Click here to play";
$mouth = $_SESSION['mouth'];
$eyes =$_SESSION['eyes'];
$skin =$_SESSION['skin'];
include "NavBar.php"; }
else {
include("NavBar2.php");
}
?>

<div id="board"></div>
<div id="buttons" style="text-align:center;">
<button id="start-button">Start the game</button>
</div>
<form onsubmit = "return false">
<button id="submit-score" style="display:block; visibility: hidden;">Submit Score</button> </form>
<div id="timer">Time: 0s</div>
<div id="message"></div>
<div id="scoreDisplay"></div>


<script>
var session = "<?php echo $session?>";
var cards = [];
var flippedCards = [];
var matchedCards = []; 
var numOfMoves = 0; 
var numOfMatches = 0;
var numofpairs = 5; 
var numofCards = 10; 
var timer = null; 
var timeElapsed = 0; 
var points = 13;
var fisrtcard = null;
// Define game board element
var board = document.getElementById("board");


function shuffleCards() {

for (let i= cards.length - 1; i > 0; i--) { 
    const j = Math.floor(Math.random() * (i + 1)); 
    const temp = cards[i];
    cards[i] = cards[j];
    cards[j] = temp;
}
while(board.firstChild){
board.removeChild(board.lastChild);
}
// Add the shuffled cards back to the board 
for (let i = 0; i < cards.length; i++) { 
    board.appendChild(cards[i]);
}
}


// Define start button element
var startButton = document.getElementById("start-button"); 
startButton.addEventListener("click", startGame);
var submitButton = document.getElementById("submit-score"); 
submitButton.addEventListener("click", submit);
// Define message element
var message = document.getElementById("message");
var scoreDisplay = document.getElementById("scoreDisplay");
// Define timer element
var timerDisplay = document.getElementById("timer");
const gameBoard = document.getElementById("game-board");
startButton.addEventListener("click", startGame);
// Define function to shuffle the cards
function shuffle(array) {
var currentIndex = array.length, temporaryValue, randomIndex; 
while (0!== currentIndex) {
randomIndex = Math.floor(Math.random() * currentIndex); 
currentIndex -= 1;
temporaryValue = array[currentIndex];
array[currentIndex] = array[randomIndex];
array[randomIndex] =temporaryValue;
}
return array;
}


// Restart the game 
function restartGame() { // Clear all arrays 
cards = [];
flippedCards = [];
 matchedCards = [];
// Reset all variables
numOfMoves = 0;
numOfMatches = 0;
numOfpairs = 5;
numOfCards = 10
timeElapsed = 0;
points = 13;
fisrtcard = null;
submitButton.style.visibility = 'hidden';
message.innerHTML = ""; 
scoreDisplay.innerHTML = "";
// Stop and reset the timer 
clearInterval(timer); 
timer = null;
timerDisplay.textContent = "Time: Os";
// Clear the board
while (board.firstChild) {
board.removeChild(board.lastChild);
}
}

﻿

// Define function to start the game 
function startGame() {
restartGame();
// Create the cards
for (var i = 0; i < num0fpairs; i++) {
const skinFolder = "emojiassests1/skin/";
 const eyesFolder="emojiassests1/eyes/"; 
 const mouthFolder = "emojiassests1/mouth/";
const randomSkin = Math.floor(Math.random() * 3) + 1; // select a random skin tone from 6 available const randomEyes = Math.floor(Math.random() * 6) + 1; // select a random eyes image from 10 available const randomMouth = Math.floor(Math.random() * 6) + 1; // select a random mouth image from 10 available for(var j=0;j<2; j++){
const card = document.createElement("div");
const front = document.createElement("div"); 
const back = document.createElement("div");
card.classList.add("card"); 
front.classList.add("front");
back.classList.add("back");
const skinImage = document.createElement("img"); 
skinImage.src = `${skinFolder} skin${randomSkin}.png`; 
skinImage.alt = "skin tone";
const eyesImage = document.createElement("img"); 
eyesImage.src = `${eyesFolder} eyes${randomEyes}.png`; 
eyesImage.alt = "eyes";
const mouthImage = document.createElement("img"); 
mouthImage.src = `${mouthFolder}mouth${randomMouth}.png`;
mouthImage.alt = "mouth";
skinImage.style.position = 'absolute'; 
skinImage.style. Top = '0px';
skinImage.style.Left = '500px';
eyesImage.style.position = 'absolute';
eyesImage.style. Top = '0px';
eyesImage.style.Left = '500px';
mouthImage.style.position = 'relative';

front.appendChild(skinImage);
front.appendChild(eyesImage);
front.appendChild(mouthImage);

card.appendChild(front);
card.appendChild(back);
card.addEventListener("click",flipcard);
cards.push(card);
}
}
shuffleCards();


for (let i = 0; i < cards.length; i++) {
     board.appendChild(cards[i]);
}
// Hide the start button
startButton.style.display = "none";
// Start the timer
timeElapsed = 0;
timerDisplay.innerHTML = "Time: 0s"; 
timer = setInterval(function() {
timeElapsed++;
timerDisplay.innerHTML = "Time: " + timeElapsed + "s";
}, 1000);

function submit(){
message.innerHTML = "SCORE SUBMITTED";
var username = "<?php echo $username?>";
var xhr = new XMLHttpRequest();
// Define the callback function to handle the server response
 xhr.onreadystatechange function() {
if (xhr.readyState === 4 && xhr.status ===200) {
// Refresh the page to display the updated leaderboard 
location.reload();
}
}
// Send the POST request to the server
xhr.open('POST', 'add_score.php');
// Create a new form data and append the data you want to send 
var formData = new FormData();
formData.append('username', username);
formData.append('score', points);
// Send the form data to the server 
xhr.send(formData);
}



function flipCard() {
if (flippedCards.length < 2 && !matchedCards.includes (this) && flippedCards.indexOf(this) === -1) {
this.classList.add("flipped");
if (flippedCards.length == 0) {
flippedCards.push(this)
firstcard = this;
} else if (flippedCards.length == 1) {
flippedCards.push(this);
// Disable clicking on other cards while animation is running
board.classList.add("disabled");
// Check if the cards match
if (flippedCards[0].querySelector(". front").innerHTML== flippedCards [1].querySelector(".front").innerHTML) { 
    flippedCards.forEach(function(card) {
        card.classList.add("matched");
matchedCards.push(card);
});

flippedCards = [];
numOfMatches++;
// Check if the game is over
if (numOfMatches == numOfCards/2) {
// Stop the timer 
clearInterval(timer);
// Calculate the points
var maxPoints = (numOfCards) * 10;
points = Math.max(0, maxPoints - (numOfMoves + timeElapsed));
// Show the start button
startButton.style.display = "block";
startButton.style.margin = "auto"
startButton.style.position="center";
if(session === "1"){
submitButton.style.visibility = 'visible';
submitButton.style.display = "block"; 
submitButton.style.margin = "auto"
}
}
// Show the final score
message.innerHTML = "Congratulations! You won with " + points + " points!";
} else {
// Cards do not match, flip them back over 
firstcard = null;
setTimeout(function() {
flippedCards.forEach(function(card) {
});
card.classList.remove("flipped");
flippedCards = [];
// Re-enable clicking on other cards
board.classList.remove("disabled");
},1000);
numOfMoves++;
scoreDisplay.innerHTML = "Moves: "+numOfMoves;
}
}
</script>
</div>
</body>
</html>