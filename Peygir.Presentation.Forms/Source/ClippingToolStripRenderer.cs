using System;
using System.Windows.Forms;

namespace Peygir.Presentation.Forms {
	internal class ClippingToolStripRenderer : ToolStripSystemRenderer {
		protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e) {
			ToolStripStatusLabel label = e.Item as ToolStripStatusLabel;

			if (label != null) {
				TextRenderer.DrawText(
					e.Graphics,
					label.Text,
					label.Font,
					e.TextRectangle,
					label.ForeColor,
					TextFormatFlags.EndEllipsis);
			}
			else {
				base.OnRenderItemText(e);
			}
		}
	}
}
