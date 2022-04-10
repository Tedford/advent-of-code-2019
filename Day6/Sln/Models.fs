namespace Day6

type Orbit = {
    Body: string;
    Satellite: string
}
   
type Body = {
    Name: string;
    Distance : int
}

type Tree = Node of Body * Tree array


