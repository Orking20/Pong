using Godot;
using System;

public partial class Bola : CharacterBody2D
{
	private Vector2 _tamanoPantalla;
	private int _velocidad;
	private Vector2 _direccion;
	//private CharacterBody2D _paletaIzq;
	//private CharacterBody2D _paletaDer;

    public override void _Ready()
    {
		this._tamanoPantalla = GetViewportRect().Size;

		//this._paletaIzq = GetNode<CharacterBody2D>("PaletaIzq");
		//this._paletaDer = GetNode<CharacterBody2D>("PaletaDer");

		int x, y;

		do
		{
			x = GD.RandRange(-1, 1);
			y = GD.RandRange(-1, 1);
			GD.Print(x, y);
		} while (x == 0 || y == 0);

		this._direccion = new Vector2(x, y);
		this._velocidad = 100;
    }

    public override void _PhysicsProcess(double delta)
	{
		this.Position += this._direccion * this._velocidad * (float)delta;

		if (this.Position.Y >= this._tamanoPantalla.Y || this.Position.Y <= 0)
		{
			this._direccion.Y *= -1; // Al colisionar con las paredes cambia de dirección
		}
	}
}
