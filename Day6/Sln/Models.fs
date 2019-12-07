namespace Day6

type Orbit = {
    Body: string;
    Satellite: string
}
   
type Body = {
    Name: string
}

type Tree = Node of string * Tree array


