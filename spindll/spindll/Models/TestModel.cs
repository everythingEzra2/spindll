using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using spindll.annotations;

namespace spindll.Models
{
	interface IDated
	{
		DateTime DateCreated { get; set; }
		DateTime DateUpdated { get; set; }
		DateTime DateDeleted { get; set; }
	}

	[SpindllMark]
	[SpindllInheritance("extends IDated")]
	[SpindllProp("//-- this is a spindll prop --")]
	class Dog //: IDated
	{
		[SpindllProp("@IsNotEmpty()")]
		public bool Fuzzy { get; set; }
		public bool Borks { get; set; }
		public string Name { get; set; }
		public DateTime BirthDate { get; set; }

		public List<int> WhurlsInts { get; set; }
		public List<Leaf> Leaves { get; set; }
		public Leaf[] ArrayLeaves { get; set; }
		public Leaf FavoriteLeaf { get; set; }
		public Leaf? currentLeaf { get; set; }

		public string testProp = "test2";
	}

	[SpindllMark]
	class Leaf
	{
		public int AgesInDays { get; set; }
		public int OrderAquired { get; set; }
		public Dog parent { get; set; }
	}
}