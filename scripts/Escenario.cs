using Godot;
using System;

public partial class Escenario : Node2D
{
	private Vector2 _tamanoPantalla;
	private CharacterBody2D _paletaIzq;
	private CharacterBody2D _paletaDer;
	private int _velocidadPaleta;

	public override void _Ready()
	{
		this._tamanoPantalla = GetViewportRect().Size;

		CharacterBody2D bola = GetNode<CharacterBody2D>("Bola");
		this._paletaIzq = GetNode<CharacterBody2D>("PaletaIzq");
		this._paletaDer = GetNode<CharacterBody2D>("PaletaDer");

		bola.Position = this._tamanoPantalla / 2;
		this._paletaIzq.Position = new Vector2(20, this._tamanoPantalla.Y / 2);
		this._paletaDer.Position = new Vector2(620, this._tamanoPantalla.Y / 2);

		this._velocidadPaleta = 150;
	}

	public override void _Process(double delta)
	{
		
	}

    public override void _PhysicsProcess(double delta)
    {
        ManejarInput();
    }

    private void ManejarInput()
    {
		this._paletaIzq.Velocity = Vector2.Zero;
		this._paletaDer.Velocity = Vector2.Zero;

		// Mueve las paletas dentro de los límites de la pantalla
		if (Input.IsActionPressed("izq_mover_arriba") && this._paletaIzq.Position >= new Vector2(20, 0))
		{
			this._paletaIzq.Velocity -= new Vector2(0, this._velocidadPaleta);
		}
		else if (Input.IsActionPressed("izq_mover_abajo") && this._paletaIzq.Position <= new Vector2(20, this._tamanoPantalla.Y))
		{
			this._paletaIzq.Velocity += new Vector2(0, this._velocidadPaleta);
		}

		if (Input.IsActionPressed("der_mover_arriba") && this._paletaDer.Position >= new Vector2(620, 0))
		{
			this._paletaDer.Velocity -= new Vector2(0, this._velocidadPaleta);
		}
		else if (Input.IsActionPressed("der_mover_abajo") && this._paletaDer.Position <= new Vector2(620, this._tamanoPantalla.Y))
		{
			this._paletaDer.Velocity += new Vector2(0, this._velocidadPaleta);
		}

		this._paletaIzq.MoveAndSlide();
		this._paletaDer.MoveAndSlide();
    }
}
