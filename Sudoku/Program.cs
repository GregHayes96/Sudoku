

class Sudoku
{
    int[,] puzzle = new int[9, 9];
    Sudoku()
    {
        Randomise();
    
    }
    
    public void Randomise()     //this will randomise the order of numbers in the sudoku board
    {
        Random r1 = new Random();
        for (int i = 0; i < 9; i++)  //fill out a row
        {
            for(int j = 0; j < 9; j++)  //fill out a column
            {
               int temp = r1.Next(10);
               
                
            }

        }

    }

    //these are the functions that check the validity of the number to be put in the box
    public bool RowCheck() 
    {
        
        return true;
    }

    public bool ColCheck() 
    { 
        
        return true; 
    }

    public bool BoxCheck()
    { 
        
        return true; 
    }
}
