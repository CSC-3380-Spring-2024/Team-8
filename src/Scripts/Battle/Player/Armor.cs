using Godot;
using System;
[GlobalClass]
public partial class Armor : Resource
{
    public enum slot{
        Head,
        Weapon,
        Torso,
        Boots
    }
    [Export] public slot Slot = slot.Torso;
    [Export] public int Speed;
	[Export] public int Attack;
	[Export] public int PhysDefense;
	[Export] public int MagicDefense;
	[Export] public int maxHP;
	[Export] public int maxMP;
    [Export]public Element[] elements = {new Element(Element.element.Fire), new Element(Element.element.Energy), new Element(Element.element.Ice), new Element(Element.element.Gale), new Element(Element.element.Physical)};
}
