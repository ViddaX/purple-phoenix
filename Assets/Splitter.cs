using UnityEngine;

namespace pp {

	public class Splitter : Block {
		private ItemProperty desiredProperty;

		public Splitter(ItemProperty desiredProperty) : base(BlockType.Splitter) {
			this.desiredProperty = desiredProperty;
		}

		public override void OnEnter (Item item) {
			if (HasMatchingProperty(item)) {
				TryMoveOrDrop(item, true);
			} else {
				TryMoveOrDrop(item, false);
			}
		}

		public bool HasMatchingProperty(Item item) {
			return item.itemType.HasProperty(desiredProperty);
		}

		public void TryMoveOrDrop(Item item, bool left) {
			int dx = 0, dy = 0;

			Vector3 dir = direction.GetDirectionVector();
			if (dir.x > 0)
				dy = left ? 1 : -1;
			else if (dir.x < 0)
				dy = left ? -1 : 1;
			else if (dir.z > 0)
				dx = left ? -1 : 1;
			else if (dir.z < 0)
				dx = left ? 1 : -1;

			Block dest = grid.Get (coords.x + dx, coords.y + dy);
			if (dest != null && dest is Conveyor) {
				dest.OnEnter(item);
			} else {
				item.Fall(new Vector3(dx, 0.0f, dy));
			}
		}
	}
}
