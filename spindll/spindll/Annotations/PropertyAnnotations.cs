using System;

namespace spindll.annotations 
{
	public class SpindllProp : System.Attribute
	{
		public SpindllProp()
		{
			// My break point never gets hit why?
			throw new Exception("Throw this to see if annotation works or not");
		}

		public SpindllProp(string customPropertyAnnotation)
		{

			// My break point never gets hit why?
			throw new Exception($"Throw - spindll custom annotations: {customPropertyAnnotation}");
		}
	}
}