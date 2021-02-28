using System;

namespace spindll.annotations 
{
	public class SpindllInheritance : System.Attribute
	{
		public SpindllInheritance()
		{
			// My break point never gets hit why?
			// throw new Exception("Throw this to see if annotation works or not");
		}

		public SpindllInheritance(string customPropertyAnnotation)
		{

			// My break point never gets hit why?
			// throw new Exception($"Throw - spindll custom annotations: {customPropertyAnnotation}");
		}
	}
}