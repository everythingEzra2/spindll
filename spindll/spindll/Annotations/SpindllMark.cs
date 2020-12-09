using System;

namespace spindll.annotations 
{
	public class SpindllMark : System.Attribute
	{
		public SpindllMark()
		{
			// My break point never gets hit why?
			// throw new Exception("Throw this to see if annotation works or not");
		}
	}
}