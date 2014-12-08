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
	[Activity (Label = "Explode", ParentActivity=typeof(MainActivity),Theme = "@style/AppThemeLight")]
	public class AnimationsActivity1 : Activity
	{
	
		GridView grid;
		protected override void OnCreate (Bundle bundle)
		{

			//Will request content Transitions with the Explode Transition
			//This can also be specified in the Style
			Window.RequestFeature (WindowFeatures.ContentTransitions);
			Window.EnterTransition = new Explode ();
			Window.ExitTransition = new Explode ();
			Window.AllowReturnTransitionOverlap = true;
			Window.AllowEnterTransitionOverlap = true;

			base.OnCreate (bundle);
			SetContentView (Resource.Layout.activity_image_list);
			ActionBar.SetDisplayHomeAsUpEnabled (true);
			ActionBar.SetDisplayShowHomeEnabled (true);
			ActionBar.SetIcon (Android.Resource.Color.Transparent);

			grid = FindViewById<GridView> (Resource.Id.grid);

			grid.Adapter = new GridAdapter (this);
			grid.ItemClick += (sender, e) => {
				var intent = new Intent(this, typeof(AnimationsActivity2));
				intent.PutExtra("id", Photos.Items[e.Position].Id);
				StartActivity(intent, ActivityOptions.MakeSceneTransitionAnimation(this).ToBundle());
			};

			// Create your application here
		}
	}
}


