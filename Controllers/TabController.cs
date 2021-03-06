﻿using System;
using System.Collections.Generic;
using UIKit;

namespace AndriFannarUmfn
{
	public class TabController : UITabBarController
	{

		UIViewController tab1, tab2, tab3;

		public TabController()
		{
			tab1 = new UIViewController();
			tab1.Title = "Leikmenn";

			tab2 = new UIViewController();
			tab2.Title = "Orange";
			tab2.View.BackgroundColor = UIColor.Orange;

			tab3 = new UIViewController();
			tab3.Title = "Red";
			tab3.View.BackgroundColor = UIColor.Red;

			var tabs = new UIViewController[] {
								tab1, tab2, tab3
						};

			ViewControllers = tabs;
		}

	}
}
