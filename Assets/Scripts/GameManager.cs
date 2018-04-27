﻿using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles online players
/// </summary>
public class GameManager : MonoBehaviour {

    private const string PLAYER_ID_PREFIX = "Player ";

    // Minimum of players to start the game
    public const int MIN_PLAYER = 2;

    // Online players
    public static Dictionary<string, Player> players = new Dictionary<string, Player>();

    /// <summary>
    /// Register a new player when it joined
    /// </summary>
    /// <param name="netID"></param>
    /// <param name="player"></param>
    public static void RegisterPlayer(string netID, Player player)
    {
        string playerID = PLAYER_ID_PREFIX  + netID;
        players.Add(playerID, player);
        player.transform.name = playerID;
    }

    /// <summary>
    /// Delete player when it disconnected
    /// </summary>
    /// <param name="playerID"></param>
    public static void UnregisterPlayer(string playerID)
    {
        players.Remove(playerID);
    }

    public static Player GetPlayer(string playerID)
    {
        return players[playerID];
    }

    // GUI debugging
    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(200, 200, 200, 500));
        GUILayout.BeginVertical();

        foreach (string playerID in players.Keys)
        {
            GUILayout.Label(playerID + " - " + players[playerID].transform.name);
        }

        GUILayout.EndVertical();
        GUILayout.EndArea();
    }

}