import {Leaf} from './Leaf';

export class Dog {

	[TS_ENFORCE: bool]
	Fuzzy: boolean;
	Borks: boolean;
	Name: string;
	BirthDate: Date;
	WhurlsInts: number[];
	Leaves: Leaf[];
	ArrayLeaves: Leaf[];
	FavoriteLeaf: Leaf;
	currentLeaf: Leaf;

}
