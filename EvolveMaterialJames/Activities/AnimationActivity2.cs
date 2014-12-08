using Android.App;
using Android.OS;
using Android.Views;
using Android.Transitions;
using AndroidLSamples.Utils;
using Android.Widget;


namespace AndroidLSamples
{
	[Activity (Label = "Explode 2", ParentActivity=typeof(MainActivity),Theme = "@style/AppThemeLight")]			
	public class AnimationsActivity2 : Activity
	{
		PhotoItem item;
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
			SetContentView (Resource.Layout.activity_animations_2);
			ActionBar.SetDisplayHomeAsUpEnabled (true);
			ActionBar.SetDisplayShowHomeEnabled (true);
			ActionBar.SetIcon (Android.Resource.Color.Transparent);

			var id = Intent.GetIntExtra ("id", 0);
			item = Photos.GetPhoto (id);
			if (item == null)
				return;


			var image = FindViewById<ImageView> (Resource.Id.image);
			image.SetImageResource (item.Image);

			var name = FindViewById<TextView> (Resource.Id.name);


			name.Text =  item.Name;
			ActionBar.Title = item.Author;
		}
	}
}

