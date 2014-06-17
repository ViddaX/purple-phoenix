using UnityEngine;
using System;
using System.Collections.Generic;

namespace pp {

	public class Combiner : Conveyor {
		private List<Item> inventory = new List<Item>();
		public Recipe recipe { set; get; }

		public Combiner(Recipe recipe) : base(BlockType.COMBINER, "spawner") {
			this.recipe = recipe;
		}

		public int GetRequiredPieceCount() {
			int count = 0;
			foreach (RecipePiece piece in recipe.pieces)
				count += piece.amount;

			return count;
		}

		public override void OnEnter (Item item) {
			item.gameObject.renderer.enabled = false;
			inventory.Add(item);

			if (inventory.Count < GetRequiredPieceCount())
				return;

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

			if (success)
				OnEnter(Spawner.Spawn(recipe.creates));
			//else
				// TODO Emit smoke
		}
	}

	public struct Recipe {
		public ItemType creates;
		public RecipePiece[] pieces;

		public Recipe(ItemType creates, params RecipePiece[] pieces) {
			this.creates = creates;
			this.pieces = pieces;
		}
	}

	public struct RecipePiece {
		public ItemType required;
		public int amount;

		public RecipePiece(ItemType required) {
			this.required = required;
			this.amount = 1;
		}

		public RecipePiece(ItemType required, int amount) {
			this.required = required;
			this.amount = amount;
		}
	}
}
