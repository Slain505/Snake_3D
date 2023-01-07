using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tags 
{
    public static string WALL = "Wall";
    public static string FRUIT = "Fruit";
    public static string BOMB = "Bomb";
    public static string TAIL = "Tail";
}

public class Metrics
{
    public static float node = 0.1f;
}

public enum PlayerDirection
{
    Left = 0,
    Up = 1,
    Right = 2,
    Down = 3,
    Count = 4
}
