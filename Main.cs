using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine ("Hello Mono World");
        Console.WriteLine("Welcome to Super Tic Tac Toe");
        
        bool isPlaying = true;
        bool gameGoing = true;
        while (isPlaying)
        {
            // Setup
            Console.WriteLine("Pregame Setup");
            gameGoing = true;
            
            int reps = 0;
            
            // Gameplay
            while (gameGoing)
            {
                reps++;
                Console.WriteLine("Game playing : " + reps);
                Console.ReadLine();
                if (reps == 5)
                {
                    gameGoing = false;
                }
            }
            
            // Play again?
            Console.WriteLine("Play again?");
            bool PlayingAgain = Console.ReadLine().ToLower().Contains("y");
            if (!PlayingAgain)
            {
                isPlaying = false;
            }
        }
        
        Console.WriteLine("Goodbye! Hope you had fun!");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }
}

public static class SuperBoard
{
    public static Board[] boards = new Board[9];
    public static string xPlayer = "X";
    public static string oPlayer = "O";
    
    public static bool Move(int boardNum, int move, int player)
    {
        if (boards[boardNum].ValidMove(move))
        {
            boards[boardNum].values[
                move] = ((player == 0) ? xPlayer : oPlayer);
            return true;
        }
        return false;
    } 
    
    public static void DisplayBoard()
    {
        Console.WriteLine("");
        // One of three biggest lines
        for (int i1 = 0; i1 < 3; i1++)
        {
            // A line for a smaller Grid
            for (int i2 = 0; i2 < 3; i2++) 
            {
                // One for each table so that i dont have to die
                for (int i3 = 0; i3 < 3; i3++) 
                {
                    // One per value in the table
                    for (int i4 = 0; i4 < 3; i4++) 
                    {
                        Console.Write(boards[i1 * 3 + i2].values[i4] + (i4 != 2 ? "|" : ""));
                    }
                    if (i3 == 2) 
                    {
                        Console.WriteLine();
                    }
                    else 
                    {
                        Console.Write("||");
                    }
                }
                
                if (i2 != 2)
                {
                    Console.WriteLine("-------------------");
                }
            }
        }
    }
}

public class Board
{
    public string[] values;
    public string xPlayer;
    public string oPlayer;
    
    public Board()
    {
        int lengthToSet = 9;
        values = new string[lengthToSet];
        for (int i = 0; i < lengthToSet; i++) 
        {
            values[i] = " ";
        }
        
        xPlayer = "X";
        oPlayer = "O";
    }
    
    public bool ValidMove(int space) 
    {
        return values[space] == " ";
    }
    
    public void Display()
    {
        Console.WriteLine();
        Console.WriteLine(values[0] + "|" + values[1] + "|" + values[2]);
        Console.WriteLine("-----");
        Console.WriteLine(values[3] + "|" + values[4] + "|" + values[5]);
        Console.WriteLine("-----");
        Console.WriteLine(values[6] + "|" + values[7] + "|" + values[8]);
        Console.WriteLine();
    }
    
    public bool HasWon(int player) 
    {
        bool[] bools = new bool[8];
        //012
        //345
        //678
        
        bools[0] = RowSame(0, 1, 2, player);
        bools[1] = RowSame(3, 4, 5, player);
        bools[2] = RowSame(6, 7, 8, player);
        bools[3] = RowSame(0, 3, 6, player);
        bools[4] = RowSame(1, 4, 7, player);
        bools[5] = RowSame(2, 5, 8, player);
        bools[6] = RowSame(0, 4, 8, player);
        bools[7] = RowSame(6, 4, 2, player);
        
        for (int i = 0; i < bools.Length; i++) 
        {
            if (bools[i])
            {
                return bools[i];
            }
        }
        
        return false;
    }
    
    public bool RowSame(int one, int two, int three, int player)
    {
        bool allSame = (player == one);
        bool allSame2 = (two == three);
        allSame = (allSame == allSame2);
        if (allSame)
        {
            return true;
        } 
        else 
        {
            return false;
        }
    }
    
    public void Move(int space, int player)
    {
        if (ValidMove(space))
        {
            values[space] = (player == 0) ? xPlayer : oPlayer;
        }
    }
}
