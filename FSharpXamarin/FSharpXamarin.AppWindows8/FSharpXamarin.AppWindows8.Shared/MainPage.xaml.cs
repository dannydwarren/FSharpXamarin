using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.FSharp.Core;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FSharpXamarin
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage : Page
	{
		public MainPage()
		{
			this.InitializeComponent();

			MyButton.Click += MyButton_Click;
		}

		private int count = 0;
		private void MyButton_Click( object sender, RoutedEventArgs e )
		{
			count = FSharpXamarin.Common.A.DoWork( count );

			//var num = new Always5.Trick2.AnyNumber1To99(2); //Restricted Access

			FSharpOption<Always5.Trick2.AnyNumber1To99> a = Always5.Trick2.CreateAnyNumber1To99(count);
			Always5.Trick2.AnyNumber1To99 b = a.Value;

            int val = Always5.Trick2.Solve( b );
			MyButton.Content = $"Button Clicked {count} times! For a value of {val}";
		}
	}
}
