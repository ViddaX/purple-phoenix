using UnityEngine;
using System;
using System.Collections.Generic;

namespace pp {

	public class Combiner : Conveyor {
		public List<Item> inventory = new List<Item>();
		public Recipe recipe { set; get; }
		private int[] amounts;

		public Combiner(BlockType type, Recipe recipe) : base(type) {
			this.recipe = recipe;
			ResetProgress();
		}

		public Combiner(Recipe recipe) : this(BlockType.Combiner, recipe) {
		}

		public override void OnEnter (Item item) {
			bool success = false;
			for (int i = 0; i < recipe.pieces.Length; i++) {
				RecipePiece p = recipe.pieces[i];
				if (p.required == item.itemType) {
					amounts[i]--;
					if (amounts[i] < 0) 
						amounts[i] = 0;

					success = true;
					break;
				}
			}

			if (success) {
				item.Destroy();
			} else {
				item.Fall(direction.GetDirectionVector());
			}

			int total = 0;
			foreach (int i in amounts) {
				total += i;
			}

			if (total == 0) {
				TryCombine();
				ResetProgress();
			}
		}

		public void ResetProgress() {
			amounts = new int[recipe.pieces.Length];

			for (int i = 0; i < amounts.Length; i++) {
				amounts[i] = recipe.pieces[i].amount;
			}
		}

		public virtual void TryCombine() {
			Item created = Item.NewItem(recipe.creates);
			created.worldPosition = worldPosition;
			items.Add(created);
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
