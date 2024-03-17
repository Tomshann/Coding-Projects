<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="UTF-8">
<title>Home</title>
<style>
/* Set body margin to ℗ to remove default browser margin */
body {
margin: 0;
}
ul {
z-index: 1;
position:relative;
}
#img1{
z-index:0;
position:absolute;
top:0;
left:0;
}
#img2{
position:absolute;
z-index: 1;
top: 0;
left:0;
}
#img3{
position:absolute;
z-index: 1;
top:150px;
left:125px;
}
#main {

position: absolute;
top: 50%;
left: 50%;
transform: translate(-50%, -50%);
width: 100%;
height: 100%;
background:
url('https://images.unsplash.com/photo-1511512578047-dfb367046420?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1742&q=80');
background-size:
cover;
background-position: center center;
text-align:center;
color:white;
}
/* Set main content background color and padding */
#content {
background-color: #fff;
padding: 20px;
}
/* Set main content width to 80% and center it horizontally */
#content-wrapper {

width: 80%;
margin: 0 auto;
}
/* Set heading font size and color */
h1 {
font-size: 2rem;
color: #333;}
/* Set paragraph font size and color */
ip {
font-size: 1.2rem;
color: #666;
}
</style>

</head> 
<body> 
<?php
session_start(); // Start the session
if (isset($_SESSION['username'])) {
// User is logged in, display the welcome message and "Click here to play" button $username = $_SESSION['username'];
$username = $_SESSION['username'];
$button_text = "Click here to play";
$eyes = $_SESSION['eyes']; 
$skin = $_SESSION['skin'];
$mouth = $_SESSION['mouth'];
$button_link = "pairs.php";

include "NavBar.php";
}
else {
// User is not logged in, display the "Register now" paragraph with a link to registration.php include "NavBar2.php";
include "NavBar2.php";
$button_text ="";
$button_link="";
$register_message = "You're not using a registered session? <a href='registration.php'>Register now</a>";
}
?>
<div id="main">
<h1 style="color: white; padding-top: 20px">Welcome to Pairs</h1>
<p><?php echo $register_message; ?></p>
<?php
if(isset($_SESSION['username'])){
    echo '<button onclick=location.href="pairs.php" type="button">Click here to play</button>';
}
?>
</div>
</body>
</html>
