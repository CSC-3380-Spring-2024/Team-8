using Godot;
using System;
[GlobalClass]
public partial class playerData : TurnData
{
    [Export]public Armor Head;
    [Export]public Armor Torso;
    [Export]public Armor Weapon;
    [Export]public Armor Boots;
}
