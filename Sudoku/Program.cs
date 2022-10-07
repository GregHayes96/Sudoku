

Sudoku game1 = new Sudoku ();
game1.printPuzzle();


class Sudoku
{
    int[,] puzzle = new int[9, 9];  //9*9 square
    int rowPos = 0, colPos = 0; //these are the co-ordinates. changed to two integers for readability in the code
    public Sudoku()
    {
        Randomise();
    }
    
    public void Randomise()     //this will randomise the order of numbers in the sudoku board
    {
        Random r1 = new Random();
        for (int i = 0; i < 9; i++)  //row
        {
            int[] blackList = new int[9];   //this is the numbers that cant be reused, cleared when it changes row
            for(int j = 0; j < 9; j++)  //column
            {
                rowPos = i;    //row
                colPos = j;    //column

                int num = r1.Next(1,10);
              

                while (!NotRepeat(num)) //the number is a repeat, get a new random
                {
                    blackList[i] = num;
                    while(!BlackCheck(ref blackList, num))  //check for a black list, get a new number if it is.
                    {
                        num = r1.Next(1, 10);
                    }

                }
                
                puzzle[rowPos, colPos] = num;//number has passed checks, assign to puzzle
                //blackList[i] = num;
            }
        }
    }

    public bool BlackCheck(ref int[] bL, int num)
    {
        int matchedNum = 0;
        matchedNum = Array.Find(bL, element => element == num);

        if (matchedNum == num) return false;    //the number is in the black list, find a new number

        return true;
    }

    public bool RowCheck(int num) //8 c1,r1
    {
       if (colPos == 0) { return true; }   //just started, row doesnt need checking as its empty

       for(int i = 0; i < colPos; i++)
        {
            if(num == puzzle[rowPos,i]){ return false; }
        }

        return true;
    }

    public bool ColCheck(int num)
    {
        if (rowPos == 0) { return true; }  //its at the top of the column, therefore its empty

        for (int i = 0; i < rowPos; i++)
        {
            if(num == puzzle[i, colPos]) { return false; }
        }
        return true;
    }

    public bool BoxCheck(int num)   //find its box index first
    {
        //int[] move = new int[] {  0, 1, 2 ,  0, 1, 2 ,  0, 1, 2  };  //takes index checks that many boxes on left side
        bool[] moveB = new bool[] { false, true, true, false, true, true, false, true, true };

        int rP = rowPos;
        int cP = colPos;

        while (moveB[rP] || moveB[cP]) 
        {
            if (!moveB[cP]) //change the column position to the top right box on the next row
            { 
                cP += 2;
                rP--;
                if (num == puzzle[rP, cP]) return false;    //does a double check, the box moved to and the one to the left as they will both need checking
                else if(num == puzzle[rP, cP-1]) return false;
                cP--;  //check done, not a repeat, move the column over to the left
            }

            if (!moveB[rP])
            {
                if (num == puzzle[rP, cP-1]) return false;
                cP--;
            }
            if (moveB[rP] && moveB[cP])
            {
                if (num == puzzle[rP, cP-1]) return false;
                cP--;
            }

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

    //public bool blackList(int num)
    //{

    //    return true;
    //}

    public void printPuzzle()
    {
        for(int i = 0; i < puzzle.GetLength(0); i++)
        {
            for(int j = 0; j < puzzle.GetLength(1); j++)
            {
                Console.WriteLine("{0}", puzzle[i, j]);
            }
          
        }  
    }

}
