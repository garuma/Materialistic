
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Util;

namespace EvolveMaterialDesign
{
	[Activity (Label = "Favorites", Icon = "@drawable/icon", Theme = "@style/EvolveMaterialTheme")]	
	public class LayoutActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			ActionBar.SetDisplayHomeAsUpEnabled (true);
			ActionBar.SetLogo (new NullDrawable (1, (int)TypedValue.ApplyDimension (ComplexUnitType.Dip, 12, Resources.DisplayMetrics)));
			ActionBar.SetDisplayUseLogoEnabled (true);
			ActionBar.SetDisplayShowHomeEnabled (true);

			SetContentView (Resource.Layout.SpacedLayout);

			var images = new Dictionary<int, int> {
				{ Resource.Id.avatarView1, Resource.Drawable.james },
				{ Resource.Id.avatarView2, Resource.Drawable.chris },
				{ Resource.Id.avatarView3, Resource.Drawable.james },
				{ Resource.Id.avatarView4, Resource.Drawable.jeremie }
			};
			foreach (var p in images)
				FindViewById<ImageView> (p.Key)
					.SetImageDrawable (new AvatarDrawable (BitmapFactory.DecodeResource (Resources, p.Value)));
		}
	}
}

