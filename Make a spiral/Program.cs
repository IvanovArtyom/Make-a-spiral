public static class Spiralizor
{
    public static void Main()
    {
        // Test
        int size = 5;
        int[,] spiral = Spiralize(size);

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
                Console.Write(spiral[i, j]);

            Console.WriteLine();
        }
        // ...should return 1 1 1 1 1
        //                  0 0 0 0 1
        //                  1 1 1 0 1
        //                  1 0 0 0 1
        //                  1 1 1 1 1
    }

    public static int[,] Spiralize(int size)
    {
        int[,] spiral = new int[size, size];
        int[] lengths = new int[size];
        lengths[0] = lengths[1] = lengths[2] = size;
        int x = 0, y = 0, dx = 0, dy = 1;

        for (int i = 3; i < size; i++)
        {
            lengths[i] = lengths[i - 1];

            if (i % 2 == 1)
                lengths[i] -= 2;
        }

        foreach (var length in lengths)
        {
            spiral = Move(spiral, ref x, ref y, dx, dy, length);
            (dy, dx) = (-dx, dy);
        }

        return spiral;
    }

    public static int[,] Move(int[,] spiral, ref int x, ref int y, int dx, int dy, int length)
    {
        for (int i = 0; i < length; i++)
        {
            spiral[x, y] = 1;
            x += dx;
            y += dy;
        }

        x -= dx;
        y -= dy;

        return spiral;
    }
}