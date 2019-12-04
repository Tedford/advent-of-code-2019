namespace Day3

module Models =

    type Direction =
    | Up
    | Down
    | Left
    | Right

    type Vector = {
        Direction : Direction;
        Magnitude: int
    }

    type Point = {
        X: int;
        Y: int;
    }

    type Location = {
        Point: Point;
        Distance: int;
    }

