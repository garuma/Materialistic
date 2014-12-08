using Android.App;
using Android.OS;
using Android.Views;
using Android.Transitions;
using AndroidLSamples.Utils;
using Android.Widget;


namespace AndroidLSamples
{


	[Activity (Label = "Move Image 2", ParentActivity=typeof(MainActivity), Theme="@style/AppThemeLight")]			
	public class AnimationsActivityMoveImage2 : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			if ((int)Build.VERSION.SdkInt >= 21) {
				//Will request content Transitions with the Move Image Transition
				//This can also be specified in the Style
				//the rest is handled by the system with the shared viewname
				Window.RequestFeature (WindowFeatures.ContentTransitions);
				Window.SharedElementEnterTransition = new ChangeImageTransform ();
				Window.SharedElementExitTransition = new ChangeImageTransform();
				Window.AllowReturnTransitionOverlap = true;
				Window.AllowEnterTransitionOverlap = true;
			}
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.activity_animations_2);
			ActionBar.SetDisplayHomeAsUpEnabled (true);
			ActionBar.SetDisplayShowHomeEnabled (true);
			ActionBar.SetIcon (Android.Resource.Color.Transparent);

			var id = Intent.GetIntExtra ("id", 0);
			var item = Photos.GetPhoto (id);
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

