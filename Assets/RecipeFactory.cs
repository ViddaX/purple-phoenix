using UnityEngine;
using System.Collections;

namespace pp
{
	public class RecipeFactory
	{
		public static Recipe NewRecipe (ItemType type)
		{

			switch (type) {
			case ItemType.Seat:
					return new Recipe (ItemType.Seat, new RecipePiece (ItemType.Leather, 4), new RecipePiece (ItemType.Cotton, 2));
			case ItemType.CarBody:
					return new Recipe (ItemType.CarBody, new RecipePiece (ItemType.Steel, 8));
			case ItemType.Wheel:
					return new Recipe (ItemType.Wheel, new RecipePiece (ItemType.Rubber, 1), new RecipePiece (ItemType.Aluminum, 1));
			case ItemType.Window:
			 		return new Recipe (ItemType.Window, new RecipePiece (ItemType.Glass, 2));
			default :
					throw new System.ArgumentException (); 
	
			}

		}
	}
}

