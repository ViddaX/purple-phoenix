using UnityEngine;
using System.Collections.Generic;

namespace pp {

	public class Builder : Combiner {
		public ProjectType project;

		public Builder(ProjectType project) : base(BlockType.Builder, project.GetRecipe()) {
			this.project = project;
		}

		public override void TryCombine () {
			grid.Money += project.GetReward();
			Alerts.ShowMessage("+ $" + project.GetReward());
		}

	}

}
