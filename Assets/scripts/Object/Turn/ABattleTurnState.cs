using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABattleTurnState {

    public enum eTurnStat
    {
        ATurn = 0,
        BTurn = 1,
        Max,
    }
    private eTurnStat currentTurn = eTurnStat.ATurn;
    public eTurnStat GetCurrentTurn { get { return currentTurn; } }
    private int turnCount = 0;
    private int BattleMember = 1;

    public ABattleTurnState(int member)
    {
        BattleMember = member;
        currentTurn = eTurnStat.ATurn;
        turnCount = 0;
    }

    
    public eTurnStat NextTurn()
    {
        turnCount++;

        int mod = turnCount % BattleMember;
        currentTurn = (eTurnStat)mod;
        return currentTurn;
    }
    
}
