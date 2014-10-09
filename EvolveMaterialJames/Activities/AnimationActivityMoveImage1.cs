using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Transitions;
using AndroidLSamples.Utils;

namespace AndroidLSamples
{
	[Activity (Label = "Move Image", ParentActivity=typeof(MainActivity))]
	public class AnimationsActivityMoveImage1 : Activity
	{
		PhotoItem item;
		TextView name;
		LinearLayout colors;
		protected async override void OnCreate (Bundle bundle)
		{


			Window.RequestFeature (WindowFeatures.ContentTransitions);
			Window.SharedElementEnterTransition = new Explode ();
			Window.SharedElementExitTransition = new Explode();
			Window.AllowExitTransitionOverlap = true;
			Window.AllowEnterTransitionOverlap = true;

			base.OnCreate (bundle);

			base.OnCreate (bundle);
			SetContentView (Resource.Layout.activity_image_detail);
			ActionBar.SetDisplayHomeAsUpEnabled (true);
			ActionBar.SetDisplayShowHomeEnabled (true);
			ActionBar.SetIcon (Android.Resource.Color.Transparent);

			var id = Intent.GetIntExtra ("id", 0);
			item = Photos.GetPhoto (id);
			if (item == null)
				return;

			name = FindViewById<TextView> (Resource.Id.name);
			colors = FindViewById<LinearLayout> (Resource.Id.colors);
			var image = FindViewById<ImageView> (Resource.Id.image);

			image.SetImageResource (item.Image);
			name.Text =  item.Name;
			ActionBar.Title = item.Author;

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.activity_animations_1);
			ActionBar.SetDisplayHomeAsUpEnabled (true);
			ActionBar.SetDisplayShowHomeEnabled (true);
			ActionBar.SetIcon (Android.Resource.Color.Transparent);
		}
	}
}


