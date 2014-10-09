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
	[Activity (Label = "Move Image", ParentActivity=typeof(MainActivity), Theme = "@style/AppThemeLight")]
	public class AnimationsActivityMoveImage1 : Activity
	{
		PhotoItem item;
		TextView name;
		LinearLayout colors;
		protected async override void OnCreate (Bundle bundle)
		{


			Window.RequestFeature (WindowFeatures.ContentTransitions);
			Window.SharedElementEnterTransition = new MoveImage ();
			Window.SharedElementExitTransition = new MoveImage();
			Window.AllowExitTransitionOverlap = true;
			Window.AllowEnterTransitionOverlap = true;

			base.OnCreate (bundle);

			base.OnCreate (bundle);

			SetContentView (Resource.Layout.activity_image_list);
			ActionBar.SetDisplayHomeAsUpEnabled (true);
			ActionBar.SetDisplayShowHomeEnabled (true);
			ActionBar.SetIcon (Android.Resource.Color.Transparent);

			var grid = FindViewById<GridView> (Resource.Id.grid);

			grid.Adapter = new GridAdapter (this);
			grid.ItemClick += (sender, e) => {
				var intent = new Intent(this, typeof(AnimationsActivityMoveImage2));
				intent.PutExtra("id", Photos.Items[e.Position].Id);


				//specify the control to move and the view id
				//this is set with android:viewName="album" 
				var image = e.View.FindViewById<ImageView>(Resource.Id.imageView);
				var options = ActivityOptions.MakeSceneTransitionAnimation(this, image, "album");
				StartActivity(intent, options.ToBundle());
			};
		}
	}
}


