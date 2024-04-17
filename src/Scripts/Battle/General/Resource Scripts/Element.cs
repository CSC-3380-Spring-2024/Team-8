using Godot;
using System;

public partial class Element : Resource
{
	public Element() {
		currentElement = element.Physical;
	}
	public Element( element CurrentElement)
	{
		currentElement = CurrentElement;
	}
	public enum element
	{
		Fire,
		Energy,
		Ice,
		Gale,
		Physical,

	}
	element currentElement;
	public enum Effect
	{
		Resist,
		Weak,
		Block,
		Drain,
		Null
	}

	[Export] Effect effect;
}

