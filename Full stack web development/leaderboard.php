

<!DOCTYPE html>
<html>
<head>
<title>Leaderboard</title>
<style>
#leaderboard {
}
table {
background-color: grey;
box-shadow: 5px 5px 5px #888888;
padding: 10px;
border-spacing: 2px;
border-collapse: separate;
width: 100%;
margin:auto;
position: center;
}
th, td {
padding: 5px;
text-align: left;
}
th {
    ackground-color: blue;
color: white;
}
#main {

position: absolute;
top: 50%;
left: 50%;
transform: translate(-50%, -50%);
width: 100%;
height: 100%;
background:url('https://images.unsplash.com/photo-1511512578047-dfb367046420?ixlib=rb-4.0.3&ixid=MnwxMjA3FDB8MHXwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1742&q=80');
background-size:cover;
background-position: center center;
text-align:center;
color:white;
}
</style>


</head>
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
include "NavBar.php";
} else {
// User is not logged in, display the "Register now" paragraph with a link to registration.php 
include "NavBar2.php";
}
?>



<?php
$leaderboard = json_decode(file_get_contents('leaderboard.json'), true);
?>
<div id=leaderboard>
<table>
<thead>
<tr>
<th>Username</th>
<th>Score</th>
</tr>
</thead>
<tbody>
<?php foreach ($leaderboard as $username => $score): ?>
<?php
// Check if the user has multiple scores
if (strpos($score, ',') !== false) {
$scores = explode(',', $score);
$max_score = max($scores);
$score_display = $max_score;
} else {
$score_display = $score;
}
?>
<tr>
<td><?php echo $username; ?></td>
<td><?php echo $score_display; ?></td> </tr>
<?php endforeach; ?>
</tbody>
</table>
</div>
</div>
</html>