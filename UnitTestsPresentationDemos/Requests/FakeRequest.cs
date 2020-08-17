using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestsPresentationDemos.Requests
{
	public class FakeRequest : Request
	{
		public override string Text { get; set; } = "FAKE";
	}
}
