
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
using Android.Util;

namespace EvolveMaterialDesign
{
	[Activity (Label = "Paper Craft", Theme = "@style/EvolveMaterialTheme")]
	public class PaperCraftActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			new ViewGroup.LayoutParams (ViewGroup.LayoutParams.WrapContent,
			                            ViewGroup.LayoutParams.WrapContent);

			SetContentView (Resource.Layout.PaperCraftLayout);

			var container = FindViewById<LinearLayout> (Resource.Id.paperContainer);
			var views = Enumerable
				.Range (0, container.ChildCount)
				.Select (i => container.GetChildAt (i))
				.Cast<TextView> ()
				.ToList ();
			var metrics = Resources.DisplayMetrics;
			var elevationDelta = TypedValue.ApplyDimension (ComplexUnitType.Dip, 1, metrics);

			foreach (var view in views) {
				view.Clickable = true;
				view.Click += (sender, e) => {
					view.TranslationZ += elevationDelta;
					UpdateElevationText (view);

				};
				view.LongClick += (sender, e) => {
					view.TranslationZ = 0;
					UpdateElevationText (view);
				};
			}
		}

		void UpdateElevationText (TextView view)
		{
			var z = view.TranslationZ;
			z = (int)(z / Resources.DisplayMetrics.Density);
			view.Text = z == 0 ? string.Empty : "z = " + z + "dp \ud83d\udea9";
		}
	}
}

