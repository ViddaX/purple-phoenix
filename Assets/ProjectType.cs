
namespace pp {

	public enum ProjectType {
		CAR,
		BIKE,
	}

	public static class ProjectTypeExtensions {

		public static Recipe GetRecipe(this ProjectType type) {
			switch (type) {
			case ProjectType.CAR:
				return new Recipe(ItemType.None, new RecipePiece[] { 
					new RecipePiece(ItemType.CarBody),
					new RecipePiece(ItemType.Wheel, 4),
					new RecipePiece(ItemType.Window, 4),
					new RecipePiece (ItemType.Seat, 4)
				});
			case ProjectType.BIKE:
				return new Recipe(ItemType.None, new RecipePiece[] { 
					new RecipePiece(ItemType.Wheel, 2), 
					new RecipePiece(ItemType.BikeBody),
					new RecipePiece(ItemType.Seat)
				});
			default:
				throw new System.NotImplementedException();
			}
		}

		public static int GetReward(this ProjectType type) {
			switch (type) {
			case ProjectType.CAR:
				return 1000;
			case ProjectType.BIKE:
				return 750;
			default:
				throw new System.NotImplementedException();
			}
		}

	}

}
