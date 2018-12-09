using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class Globals {
    public static List<Tuple<float, float, string>> ATMLOCATIONS { get; set; }
    public static int playerBalls { get; set; }
    public static int playerTreats { get; set; }
    public static int playerDogs { get; set; }
    public static float playerCash { get; set; }
    public static float storeOffset { get; set; }
    public static Dictionary<string, int> playerPills = new Dictionary<string, int>();
    public static Dictionary<string, int> playerFoods = new Dictionary<string, int>();
}
