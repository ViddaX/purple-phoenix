using UnityEngine;
using System.Collections;

namespace pp{
public class RecipeFactory {
	public static Recipe NewRecipe(ItemType type) {

			switch (type) 
			{
			case ItemType.Seat:
				return new Recipe(ItemType.Seat, new RecipePiece(ItemType.Leather, 4), new RecipePiece(ItemType.Cotton,2));
			case ItemType.Car_body:
				return new Recipe(ItemType.Car_body,new RecipePiece(ItemType.Steal,8));
			case ItemType.Wheel:
				return new Recipe(ItemType.Wheel, new RecipePiece(ItemType.Rubber,1), new RecipePiece(ItemType.Aluminum,1));
			case ItemType.Window :
				return new Recipe (ItemType.Window, new RecipePiece(ItemType.Glass,2));
			case ItemType.Car:
				return new Recipe(ItemType.Car, new RecipePiece(ItemType.Wheel,4), new RecipePiece(ItemType.Car_body,1), new RecipePiece(ItemType.Seat,4), new RecipePiece(ItemType.Window,4));
			default :
				throw new System.ArgumentException(); 
				
			}

		}
	
	
	
	}
}

