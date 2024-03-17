
<?php
// Set cookie parameters
$cookie_name = "pairs_user";
$cookie_value = "";
$cookie_expire = time() + (86400 * 30); // 30 days
$parent_folder = "/var/www/html/emoji assets";
// Check if form is submitted
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
// Get username from form
$username = $_POST['username'];
// Validate username
$invalid_chars = array("!", "@", "#","%","&","*","(",")","+","=","^","{","}","[","]","-",";",":","\"","'","<",">","?","/");
foreach ($invalid_chars as $char) {
if (strpos($username, $char) !== false) {
$error = "Invalid characters in username. Please enter a new username."; 
break;
}
}
// Set cookie with username and default avatar
if (!isset($error)) {
$cookie_value = array("username" => $username, "avatar" => "default");
setcookie($cookie_name, json_encode($cookie_value), $cookie_expire);
session_start();
$_SESSION['username'] = $username;
$_SESSION['eyes']=$_POST['eyes']; $_SESSION['mouth']=$_POST['mouth'];
$_SESSION['skin']=$_POST['skin'];
header("Location: index.php");
exit();
}
}
$eyes_dir = $parent_folder."/eyes/"; 
$mouths_dir = $parent_folder."/mouth/";
$skins_dir = $parent_folder."/skin/";
$eyes = array_diff(scandir($eyes_dir), array('.','..' ));
$mouths = array_diff(scandir($mouths_dir), array('.','..')) ;
$skins = array_diff(scandir($skins_dir), array('.','..'));
?>
<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="UTF-8">
<title>Register</title>
<style>
/* Set body margin to to remove default browser margin */ 
body {

margin: 0;
}

/* Set z-index of navbar to 1 to bring it to the front */
nav {
z-index:1;
position: absolute;
top: 0;
left: 0;
width: 100%;
}
ul {
z-index:1;
position:relative;
}

/* Style the navigation links */
nav ul {

margin: 0;
padding: 0;
list-style: none;
background-color: #333;
text-align: center;
}
nav li {

display: inline-block;
margin: 0;
}
nav a {
display: block;
padding: 10px;
color: #fff;
text-decoration: none;
}
nav a:hover{
background-color: #666;
}
#main {
position: absolute;
top: 50%;
left: 50%;
transform: translate(-50%, -50%);
width: 100%;
height: 100%;
background-image: url('https://images.unsplash.com/photo-1511512578047-dfb367046420?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1742&q=80'); background-size: cover;
background-position: center center;
color:white;
}
.img1{
z-index:0;
position:absolute;
top:300;
left:300;
}
.img2{
position:absolute; 
z-index: 1;
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
color: #333;
}


/* Set paragraph font size and color */
P {
font-size: 1.2rem;
color: #666;
}
</style>
</head>
<body>
<?php include 'NavBar2.php'; ?>
<div id="main">
<h1 style="padding-top: 20px; color: white; ">Registration</h1> <form method="post">
<label for="username">Username:</label>
<input type="text" id="username" name="username" required> 
<?php if (isset($error)) { echo "<p>$error</p>"; } ?>
<br>
<label for="avatar">Avatar:</label>
<br>
<label for="eyes">Eyes:</label>
<select id="eyes" name="eyes" onchange = "updateFace()">
<?php foreach ($eyes as $eye) { ?>
<option value="<?php echo $eye; ?>"><?php echo substr($eye,0,-4); ?></option> <?php } ?>
</select>
<br>
<label for="mouth">Mouth: </label>
<select id="mouth" name="mouth" onchange = "updateFace()">
<?php foreach ($mouths as $mouth) { ?>
<option id=mouth value="<?php echo $mouth; ?>"><?php echo substr($mouth,0,-4); ?></option> <?php } ?>
</select>
<br>
<label for="skin">Skin:</label>
<select id="skin" name="skin"onchange = "updateFace()">
<?php foreach ($skins as $skin) { ?>
<option value="<?php echo $skin; ?>"><?php echo substr($skin,0,-4);?></option> <?php } ?>
</select> <br><br>
</form>
<input type="submit" value="Register">
<img class= img1 id = skinimg src="emoji assets/skin/<?php echo $skin?>"></img> <img class=img2 id= eyesimg src="emoji assets/eyes/<?php echo $eye?>"></img> <img class=img2 id mouthing src = "emoji assets/mouth/<?php echo $mouth?>"></img>
<script>
function updateFace(){
var mouth = document.getElementById('mouth').value; 
mouthing=document.getElementById('mouthing');
mouthing.src = "emoji assets/mouth/"+ mouth;
var eyes = document.getElementById('eyes').value; 
eyeimg = document.getElementById('eyesimg'); 
eyeimg.src = "emoji assets/eyes/"+ eyes;

var skin = document.getElementById('skin').value; 
skinimg = document.getElementById('skinimg');
skinimg.src = "emoji assets/skin/"+ skin;

}
</script>
</div>
</body>
</html>
