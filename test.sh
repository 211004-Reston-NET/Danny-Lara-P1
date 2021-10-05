# This is a comment to add more information to your code

echo Hello
echo World

msg="Hello World"

echo $msg

echo What is your name?
read userInput
echo Hello, $userInput! Welcome to Programming!

# For loop syntax:

for var in 1 2 3 4 5
do
	echo $var
	echo This variable currently holds: $var
done

for i in {1..10..1} #{starting number..end number..incrument by}
do
	echo $i
done

# While loop syntax:

condition="true"

while [ "$condition" != "false" ] #spaces are important here!
do
	echo "Do you want to repeat? (true or false)"
	read condition
	echo "You typed: $condition"
done

# If syntax

if [ 2 = 2 ]
then
	echo "This is inside the if-statement"
fi
