using Godot;
using System;
using System.Diagnostics;
using System.Threading;

public partial class ActionManager : Node
{ 
    TurnComponent player_data;
    public void _on_button_pressed()
    {
        // Button: Attack
        // Need to grab enemy and player health for manipulation..
        

        // Enemy reciprocates damage
        System.Threading.Thread.Sleep(10000);
        player_data = Global.involvedInBattle;
        player_data.turnData.currentHP -= 5;
        BattleScreen.UpdateLabelData(0);
        Global.active_turn = (TurnData.type)0;
    }
    public void _on_button2_pressed()
    {
        // Button: Skills
    }
    public void _on_button3_pressed()
    {
        // Button: Items
    }
    public void _on_button4_pressed()
    {
        // Button: Equipment
    }
    public void _on_button5_pressed()
    {
        // Button: Defend
    }
    public void _on_button6_pressed()
    {
        // Button: Flee
        
    }
}
