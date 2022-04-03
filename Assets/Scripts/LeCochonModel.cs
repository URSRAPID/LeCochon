using UnityEngine;
using System.Linq;

public enum VALUE
{
    Un,
    Deux,
    Trois,
    Quatre,
    Cinq,
    Six
}
public class LeCochonModel : MonoBehaviour
{
    private DesObservable[,] _grid;

    public LeCochonModel()
    {
        _grid = new DesObservable[3, 1];
        for (int x = 0; x < _grid.GetLength(0); x++)
        {
            for (int y = 0; y < _grid.GetLength(1); y++)
            {
                _grid[x, y] = new DesObservable(VALUE.Un);
            }
        }
    }
    public void Set(int x, int y, VALUE symbol)
    {
            _grid[x, y].Set(symbol);
    }

    internal void Subscribe(int x, int y, DesView tile)
    {
        _grid[x, y].Subscribe(tile);
    }

    internal VALUE GetValue(int x, int y)
    {
        return _grid[x, y].GetValue();
    }
    public bool IsWin(VALUE value)
    {
        //Pour une ligne
        bool win = CheckSuite(0, value)
                || CheckSuite(1, value)
                || CheckSuite(2, value);
        return win;
    }

    private bool CheckSuite(int y, VALUE value)
    {
        int x = 0;
        bool findOtherValue = false;

        while (!findOtherValue && x < 3)
        {
            findOtherValue = !_grid[x, y].IsValue(value);
            x++;
        }

        return !findOtherValue;
    }
    


    
}
