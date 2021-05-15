<html>
<body>
<form method="post">
 <input type="text" name="Number" >
 <button name="submit">Submit</button>
</form>
</body>
</html>
<?php
$conn = mysqli_connect('localhost','root','','myDB');

$sql = "CREATE DATABASE myDB1";
if ($conn->query($sql) === TRUE) {
  echo "Database created successfully";
} 
$sql = "CREATE TABLE MyProgram1 (
Number INT(300) NOT NULL,
)";

if ($conn->query($sql) === TRUE) {
  echo "Table MyProgram1 created successfully";
} 

if (isset($_POST['submit'])) {
  $n=$_POST['Number'];
  $number1 = 2;
  $number2 = 1;
}
$conn->close();
?>
<?php> 
if(isset(numbers)){?>
<h1>Table from mydb1<h1>
<table>
	<thead>
		<tr>
			<th colspan="1">number</th>
			<th colspan="2">value</th>
		</tr>
	</thead>
</table>

<?php>
foreach($numbers= as $value)
{
	echo "<tr>";
	echo "<td>value</td>";
	echo "</tr>";
}
?>	