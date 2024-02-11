using Godot;
using Godot.Collections;
using System;
[GlobalClass]

public partial class EnemyData : TurnData
{
	new type TurnType = type.ENEMY;
	[Export]public Resource template;
	[Export]public Texture2D sprite;
	[Export]public bool pass;
	[Export]public Element[] elements = {new Element(Element.element.Fire), new Element(Element.element.Energy), new Element(Element.element.Ice), new Element(Element.element.Gale), new Element(Element.element.Physical)};
}


