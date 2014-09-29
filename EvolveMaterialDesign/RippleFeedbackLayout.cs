
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

namespace EvolveMaterialDesign
{
	[Activity (Label = "Ripple", Icon = "@drawable/icon", Theme = "@style/EvolveMaterialTheme")]			
	public class RippleFeedbackLayout : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.RippleFeedbackLayout);
		}
	}
}

