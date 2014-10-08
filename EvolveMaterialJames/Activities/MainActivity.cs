using System;
using System.Linq;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using Android.Util;
using Android.Animation;
using Android.Views.Animations;

namespace AndroidLSamples
{
	[Activity (Label = "Materialistic", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/EvolveMaterialTheme")]	
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.main);

			var btns = new int[] {
				Resource.Id.layoutBtn,
				Resource.Id.rippleBtn,
				Resource.Id.inkBtn,
				Resource.Id.drawableAnimBtn
			}.Select (FindViewById<Button>).ToArray ();

			btns[0].Click += (sender, e) => 
			{
				var intent = new Intent(this, typeof(ThemesActivity));
				intent.PutExtra("theme", 0);
				StartActivity (intent);
			};
			btns[1].Click += (sender, e) =>
			{
				var intent = new Intent(this, typeof(ThemesActivity));
				intent.PutExtra("theme", 1);
				StartActivity (intent);
			};
			btns[2].Click += (sender, e) => 
			{
				var intent = new Intent(this, typeof(ThemesActivity));
				intent.PutExtra("theme", 2);
				StartActivity (intent);
			};
			//btns[3].Click += (sender, e) => StartActivity (typeof(AnimatedDrawableActivity));
			//btns[2].Click += (sender, e) => MakeStartAnimations (btns);

			MakeStartAnimations (btns);
		}

		void MakeStartAnimations (Button[] btns)
		{
			for (int i = 0; i < btns.Length; i++) {
				var anim = PrepareAnimation (btns [i], (i % 2) == 0 ? -1 : 1);
				anim.StartDelay = i * 75 + 10;
				anim.Start ();
			}
		}

		ObjectAnimator PrepareAnimation (View view, int multiplier)
		{
			var path = new Path ();

			var metrics = Resources.DisplayMetrics;
			var tx = multiplier * (metrics.WidthPixels - view.PaddingRight);
			var ty = -TypedValue.ApplyDimension (ComplexUnitType.Dip, 64, metrics);

			path.MoveTo (tx, ty);
			path.QuadTo (2 * tx / 3, 0, 0, 0);
			view.TranslationX = tx;
			view.TranslationY = ty;

			var anim = ObjectAnimator.OfFloat (view, "translationX", "translationY", path);
			anim.SetDuration (600);
			anim.SetInterpolator (AnimationUtils.LoadInterpolator (this, Android.Resource.Interpolator.LinearOutSlowIn));

			return anim;
		}
	}
}
