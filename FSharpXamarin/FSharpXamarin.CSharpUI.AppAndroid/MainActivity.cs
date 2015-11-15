using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.FSharp.Core;

namespace FSharpXamarin.CSharpUI.AppAndroid
{
	[Activity( Label = "FSharpXamarin.CSharpUI.AppAndroid", MainLauncher = true, Icon = "@drawable/icon" )]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate( Bundle bundle )
		{
			base.OnCreate( bundle );

			// Set our view from the "main" layout resource
			SetContentView( Resource.Layout.Main );

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button>( Resource.Id.MyButton );

			button.Click += delegate
			{
				count = count + 1;

				//var num = new Always5.Trick2.AnyNumber1To99(2); //Restricted Access

				FSharpOption<Always5.Trick2.AnyNumber1To99> a = Always5.Trick2.CreateAnyNumber1To99( count );
				Always5.Trick2.AnyNumber1To99 b;
				try
				{
					b = a.Value;
				}
				catch ( NullReferenceException ex )
				{
					return;
				}

				int val = Always5.Trick2.Solve( b );
				button.Text = $"Button Clicked {count} times! For a value of {val}";
			};
		}
	}
}

