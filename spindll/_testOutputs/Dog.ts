import { Leaf } from './Leaf';

//-- this is a spindll prop --
export class Dog extends IDated{

	@IsNotEmpty()
	Fuzzy: boolean;
	Borks: boolean;
	Name: string;
	BirthDate: Date;
	WhurlsInts: number[];
	Leaves: Leaf[];
	ArrayLeaves: Leaf[];
	FavoriteLeaf: Leaf;
	currentLeaf: Leaf;
	LastChecked: Date;

}
