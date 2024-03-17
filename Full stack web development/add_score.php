

<?php
echo var_dump($_POST);
$username = $_POST['username'];
$score = $_POST['score'];
// Call the add_score function with the retrieved username and score 
add_score($username, $score);
function add_score ($username, $score) {
// Load the leaderboard from the JSON file
$Leaderboard = json_decode(file_get_contents('leaderboard.json'), true);
// Check if the username and score are not empty
if (!empty($username) && !empty($score)) {
    $leaderboard [$username] = $score;
}


// Sort the leaderboard in descending order of scores
arsort ($leaderboard);
// Save the leaderboard to the JSON file
file_put_contents('leaderboard.json', json_encode($leaderboard));
}
?>