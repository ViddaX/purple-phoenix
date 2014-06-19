using UnityEngine;
using System.Collections.Generic;

namespace pp {

	public class Builder : Combiner {
		public ProjectType project;

		public Builder(ProjectType project) : base(BlockType.Builder, project.GetRecipe()) {
			this.project = project;
		}

		public override void TryCombine () {
			// copy paste ftw
			// Check if the input matches the recipe
			bool success = true;
			foreach (RecipePiece piece in recipe.pieces) {
				List<Item> matching = inventory.FindAll(x => x.itemType == piece.required);
				
				if (matching.Count != piece.amount) {
					success = false;
					break;
				}
			}
			
			foreach (Item i in inventory)
				i.Destroy();
			
			inventory.Clear();
			
			if (success) {
				grid.Money += project.GetReward();
				Alerts.ShowMessage("+ $" + project.GetReward());
			}
		}

	}

}
