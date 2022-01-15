<?php
if(isset($_POST['name'], $_POST['email'], $_POST['message'])){
    print_r($_POST);
    echo 'your name is ' . $_POST['name'];
}