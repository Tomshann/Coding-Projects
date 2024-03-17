
<!DOCTYPE html>
<html>
<head>
<style> ul {
list-style-type: none; 
margin:0;
padding-top: 0.4cm;
height: 0.7cm;
overflow: hidden;
background-color: blue;
}
li{
    float: right;
}
li a{
padding: 15px 20px;
text-align: center;
color:white;
font: Verdana;
font-size: 12px;
text-decoration: none;
}
a:hover{
background-color:#ADD8E6;
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
top:0px;
left:0px
}

#img3{
position:absolute;
z-index:1;
top:0px;
left:0px;
}

</style>
<?php
if (isset($_SESSION['username'])){ 
$mouth = $_SESSION['mouth'];
$eyes = $_SESSION['eyes'];
$skin = $_SESSION['skin'];
}
?>
</head> <body>
<ul>
<li style="float: left;"><a name="home" href="index.php"><b>Home</b></li>
<a><img id="img3" src = "emoji assets/mouth/<?php echo $mouth?>" alt="Mouth" width="40" height="40"></a> 
<a><img id="img2" src = "emoji assets/eyes/<?php echo $eyes?>" alt="eyes" width="40" height="40"></a>
<a><img id="img1"src = "emoji assets/skin/<?php echo $skin?>" alt="skin" width="40" height="40"></a> 
<li><a name="leaderboard" href="leaderboard.php"><b>Leaderboard</b></a></li>
<li><a name="memory" href="pairs.php"><b>Play Pairs</b></a></li>
</ul>
</body>
</html>