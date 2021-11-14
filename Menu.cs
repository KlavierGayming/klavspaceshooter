using Godot;
using System;

public class Menu : Control
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	
	OptionButton button;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		button = GetNode<OptionButton>("OptionButton");
		additems();
	}
	private void _on_OptionButton_item_selected(int index)
	{
		var arr = new string[] {"normal", "dodge", "infinite"};
		var descs = new string[] {"Regular mode. you need 1500 score for ending", "Dodge mode. You can't shoot and you need to survive.", "Infinite mode. Normal but never ends."};
		var dir = new Directory();
		dir.Remove("user://mode.txt");
		var file = new File();
		file.Open("user://mode.txt", File.ModeFlags.WriteRead);
		file.StoreString(arr[index]);
		GD.Print(file.GetAsText());
		file.Close();
		GetNode<RichTextLabel>("ModeDescLabel").Text = descs[index];
	}
	private void additems()
	{
		var array = new string[] {"Normal", "Dodge", "Infinite"};
		var descs = new string[] {"Regular mode. you need 1500 score for ending", "Dodge mode. You can't shoot and you need to survive.", "Infinite mode. Normal but never ends."};
		for (int i = 0; i < array.Length; i++)
		{
			button.AddItem(array[i]);
		}
		button.Select(getmode());
		GetNode<RichTextLabel>("ModeDescLabel").Text = descs[getmode()];
	}
	int getmode() {
		var arr = new string[] {"normal", "dodge", "infinite"};
		var file = new File();
		file.Open("user://mode.txt", File.ModeFlags.ReadWrite);
		var con = 0;
		switch (file.GetAsText()) {
			case "dodge":
				con = 1;
				break;
			case "infinite":
				con = 2;
				break;
		}
		file.Close();
		return con;
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
	private void _on_Button_pressed()
	{
		GetTree().ChangeScene("res://main.tscn");
	}
}









