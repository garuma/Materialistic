using Android.App;
using Android.OS;
using Android.Widget;


namespace AndroidLSamples
{
	[Activity (Label = "Themed Controls", ParentActivity=typeof(MainActivity))]			
	public class ThemesActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			var theme = Intent.GetIntExtra ("theme", 0);

			switch(theme){
			case 0:
				SetTheme (Resource.Style.MaterialDark);
				break;
			case 1:
				SetTheme (Resource.Style.MaterialLight);
				break;
			case 2:
				SetTheme (Resource.Style.AppThemeLight);
				break;
			}
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.activity_themes);
			ActionBar.SetDisplayHomeAsUpEnabled (true);
			ActionBar.SetDisplayShowHomeEnabled (true);
			ActionBar.SetIcon (Android.Resource.Color.Transparent);

		}

		public override bool OnCreateOptionsMenu (Android.Views.IMenu menu)
		{
			MenuInflater.Inflate (Resource.Menu.menu2, menu);
			return base.OnCreateOptionsMenu (menu);
		}
	}
}

