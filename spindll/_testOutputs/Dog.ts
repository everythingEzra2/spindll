import { Leaf } from './Leaf';

export class Dog {

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

}
