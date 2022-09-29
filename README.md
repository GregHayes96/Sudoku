# Sudoku  V1
Basic frame for a sudoku game which can randomise each time

I have outlined below the rules and the rules to follow for creating the algorithm.
My structure will be through implementing three seperate class methods which will run each check.

Rules for sudoku:
Game is filled with numbers from 1 - 9.
Square is made up of single cells in a 9*9 format.
Each 3*3 square should have the numbers 1 - 9.
Each row ld have the numbers 1-9.
Each column should have the numbers 1-9.
There should be no repeat numbers in any of the squares, rows or coloumns.

How the class will run
-The game should be randomised for repeat playing.
-The player will only see some of numbers and has to figure out the rest.
-When the player enters all the numbers correctly, the guess will be compared to the class array and give a win message.
-The game will randomise and start again.

Algorithm for creating a new game
-The boc can be boken down into rows, coloumns and boxes. 
-R1-R9	C1-C9	B1-B9.
-R1 will be filled across.
-R2,C1 will start to fill. The number will run 3 checks to see if its valid.

Check 1: Row 
-Is the number in the row above a repeat?
-This is repeated until R1 in the matching column has been confirmed not a repeat.
Check has been passed.

Check 2: Column
-Is the number in the column along a repeat?
-This is repeated until C1 in the same row has been confirmed not a repeat.
Check has passed.

Check 3: Box
-is the number in box a repeat?
-This starts at the first number in the current box (B1-9), the first row in the box (R1/4/7) and the first column in the box (C1/4/7)
-The check moves along a column until it checks the last number in the column, now it moves back to thefirst column on the row down.
-Repeat until all numbers have been checked.
-Check has passed.

Now all checks have been passed. It's not a repeat number so it can be placed in the original index of the sudoku square array.

If the check does not pass, generate a new random number and start the checks again. The random number should be black listed until the check has passed.
