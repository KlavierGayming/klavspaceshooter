using Godot;
using System;

public class GameOver : Control
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
	private void _on_RetryButton_pressed()
	{
		GetTree().ChangeScene("res://main.tscn");	
	}
	private void _on_LeaveButton_pressed()
	{
		GetTree().ChangeScene("res://Menu.tscn");	
	}
}






