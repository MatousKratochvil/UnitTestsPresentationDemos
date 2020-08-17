using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestsPresentationDemos.Responses
{
	public class FakeResponse : Response
	{
		public override string Text { get; set; } = "FAKE";
	}
}
