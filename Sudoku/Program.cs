

Sudoku game1 = new Sudoku ();


class Sudoku
{
    int[,] puzzle = new int[8, 8];  //9*9 square
    int[] position = new int[2];    //the location of number in the grid array  [0] row, [1] column
    int[] blackList = new int[8];
    public Sudoku()
    {
        Randomise();
    
    }
    
    public void Randomise()     //this will randomise the order of numbers in the sudoku board
    {
        Random r1 = new Random();
        for (int i = 0; i < 9; i++)  //row
        {
            for(int j = 0; j < 9; j++)  //column
            {
                position[0] = i;    //row
                position[1] = j;    //column

               
               int temp = r1.Next(1,10);
                
               while(NotRepeat(temp) == false) //the number is a repeat, get a new random
                {
                    temp = r1.Next(1, 10);

                }
                puzzle[position[0], position[1]] = temp;    //number has passed checks, assign to puzzle
                
            }

        }

    }

    public bool RowCheck(int num) //8 c1,r1
    {
       if (position[1] == 0) { return true; }   //just started, row doesnt need checking as its empty

       for(int i = 0; i < position[1]; i++)
        {
            if(num == puzzle[position[0],i]){ return false; }
        }

        return true;
    }

    public bool ColCheck(int num)
    {
        if (position[0] == 0) { return true; }  //its at the top of the column, therefore its empty

        for (int i = 0; i < position[0]; i++)
        {
            if(num == puzzle[i, position[1]]) { return false; }
        }
        return true;
    }

    public bool BoxCheck(int num)   //find its box index first
    {
        int[] row = new int[] {  0, 1, 2 ,  0, 1, 2 ,  0, 1, 2  };  //the index for the row takes the number and checks that many boxes left
        bool skipFirst = false;

        for (int i = row[position[1]]; i > -1; i--) //column decrease
        {
            if (!skipFirst) //this takes the index of the current position.
            { 
                for (int j = row[position[0]]; j > -1; j--) //row decrease
                {
                    if(num == puzzle[(position[0] - j), (position[1]-i)]) return false; 
                    if (i == 0 && j == 0) { return true; }
                } 
            }
            if (skipFirst)  //this now moves up a row and goes into the third index of the row
            {
                for (int j = 2; j > -1; j--)
                {
                    if (num == puzzle[(position[0] - j), (position[1] - i)]) return false;  //this has an array out of range error
                    if (i == 0 && j == 0) { return true; } //no matches in the box area
                }
            }

            skipFirst = true;
        }

        return true; 
    }

    public bool NotRepeat(int num)
    {   //if all numbers methods return a true, it means the number is safe to place in the sudoku box
        if (!RowCheck(num)) return false;
        if (!ColCheck(num)) return false;
        if (!BoxCheck(num)) return false;
        return true;
    }
}
