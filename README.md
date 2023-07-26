## Description:
Your task, is to create a NxN spiral with a given ```size```.

For example, spiral with size 5 should look like this:
```
00000
....0
000.0
0...0
00000
```
and with the size 10:
```
0000000000
.........0
00000000.0
0......0.0
0.0000.0.0
0.0..0.0.0
0.0....0.0
0.000000.0
0........0
0000000000
```
Return value should contain array of arrays, of ```0``` and ```1```, with the first row being composed of ```1```s. For example for given size ```5``` result should be:
``` C#
[[1,1,1,1,1],[0,0,0,0,1],[1,1,1,0,1],[1,0,0,0,1],[1,1,1,1,1]]
```
Because of the edge-cases for tiny spirals, the size will be at least 5.

General rule-of-a-thumb is, that the snake made with '1' cannot touch to itself.
### My solution
```C#
public class Spiralizor
{
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
```
