using UnityEngine;

namespace pp {

	public class IronSheet : Item {
		public IronSheet() : base(ItemType.IRON_SHEET, "iron_sheet") {
		}

		public override bool CanCombine (ItemType type) {
			return false;
		}

		public override Item Combine (Item item) {
			throw new System.NotImplementedException ();
		}
	}

}