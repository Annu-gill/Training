using System;

// Deep-nested loop search using goto
static class SearchWithGoto
{
    public static void Execute()
    {
        int[,] arr = { {1,2,3},{4,5,6},{7,8,9} };
        int key = 5;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (arr[i, j] == key)
                    goto FOUND;
            }
        }

        Console.WriteLine("Not Found");
        return;

    FOUND:
        Console.WriteLine("Element Found");
    }
}
