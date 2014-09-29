
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Graphics.Drawables;

namespace EvolveMaterialDesign
{
	public class NullDrawable : ColorDrawable
	{
		int height, width;

		public NullDrawable (int height, int width) : base (Color.Transparent)
		{
			this.height = height;
			this.width = width;
		}

		public override int IntrinsicHeight {
			get { return height; }
		}

		public override int IntrinsicWidth {
			get { return width; }
		}
	}
}

