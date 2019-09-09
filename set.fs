//
// Shyam Patel (NetID: spate54)
// U. of Illinois, Chicago
// CS 341, Fall 2018
// Project #04: Sets in F#
//

module Set

#light

//
// returns true if set S is empty [], false if not
//
let isEmpty S =
  match S with
  | [] -> true   // S is empty
  | _  -> false  // S is not empty


//
// returns true if x is in S, false if not
//
let rec isMember x S =
  match S with
  | []   -> false                            // end of list : ret F
  | e::r -> (not (e < x) && not (x < e)) ||  // is x in S?
            isMember x r                     // if not, check the rest


//
// returns the # of elements in the set
// NOTE: uses tail recursive helper to return size
//
let rec private _size sizeSoFar S =
  match S with
  | []   -> sizeSoFar                // end of list : ret count
  | _::r -> _size (sizeSoFar + 1) r  // increment count + check rest

let size S =
  _size 0 S  // call tail recursive helper


//
// inserts x into S, returning the new set S'
//
// NOTE #1: elements are inserted in order using <.
// NOTE #2: if x exists in S, then S is returned unchanged.
//
let rec insert x S =
  match S with
  | []              -> [x]            // end of list     : ret [x]
  | e::r when e < x -> e::insert x r  // prepend e in S'
  | e::_ when x < e -> x::S           // prepend x in S' : ret S'
  | _               -> S              // x exists in S   : ret S


//
// removes x from S, returning the new set S'
//
// NOTE: if x is not in S, then S is returned unchanged.
//
let rec remove x S =
  match S with
  | []   -> []             // end of list : ret empty list
  | e::r when not (e < x) && not (x < e)
         -> remove x r     // e is    x : skip element
  | e::r -> e::remove x r  // e isn't x : prepend element


//
// returns true is A is a subset of B, false if not
//
let rec subset A B =
  match A with
  | []   -> true             // end of list : ret T
  | e::r -> isMember e B &&  // is A's element in B?
            subset r B       // if so, check the rest


//
// returns true if A and B contain the same elements,
// false if not
//
let rec equivalent A B =
  match A, B with
  | []    , []     -> true              // end of both lists : ret T
  | []    , _      -> false             // end of list A     : ret F
  | _     , []     -> false             // end of list B     : ret F
  | e1::r1, e2::r2 -> not (e1 < e2) &&
                      not (e2 < e1) &&  // are A and B's elements equal?
                      equivalent r1 r2  // if so, check the rest


//
// returns A union B
//
// Example:
//   A = [1;2;3;4]
//   B = [2;5;6]
//   ==> [1;2;3;4;5;6]
//
let rec union A B =
  match A, B with
  | []    , _      -> B                // end of list A : ret B
  | _     , []     -> A                // end of list B : ret A
  | e1::r1, _      when isMember e1 B  // A's element is in B :
                   -> union r1 B       //   skip element
  | _     , e2::r2 when isMember e2 A  // B's element is in A :
                   -> union A r2       //   skip element
  | e1::r1, e2::_  when e1 < e2        // A's element < B's element :
                   -> e1::union r1 B   //   insert A's element
  | _     , e2::r2 -> e2::union A r2   // else : insert B's element


//
// returns A intersect B
//
// Example:
//   A = [1;2;3;4]
//   B = [2;4]
//   ==> [2;4]
//
let rec intersection A B =
  match A with
  | []   -> []                   // end of list : ret empty list
  | e::r when isMember e B       // A's element is in B :
         -> e::intersection r B  //   prepend element
  | _::r -> intersection r B     // else, skip element


//
// returns A - B
//
// Example:
//   A = [1;2;3;4]
//   B = [2;4]
//   ==> [1;3]
//
let rec difference A B =
  match A with
  | []   -> []                 // end of list : ret empty list
  | e::r when isMember e B     // A's element is in B :
         -> difference r B     //   skip element
  | e::r -> e::difference r B  // else : prepend element


//
// returns the cartesian product of A and B:
//
// Example:
//   A = [1;2]
//   B = [3;4]
//   ==> [ [1;3]; [1;4]; [2;3]; [2;4] ]
//
let rec private _product2 x B =
  match B with
  | []   -> []                        // end of list B : ret empty list
  | e::r -> [x::[e]] @ _product2 x r  // prepend A's element to B's element

let rec private _product1 A B =
  match A with
  | []   -> []                             // end of list A : ret empty list
  | e::r -> _product2 e B @ _product1 r B  // call recursive helper #2

let product A B =
  match A, B with
  | [], _  -> [[]]           // list A is empty : ret [[]]
  | _ , [] -> [[]]           // list B is empty : ret [[]]
  | _ , _  -> _product1 A B  // call recursive helper #1


//
// returns the set containing all possible subsets:
//
// Example:
//   S = [1;2;3]
//   ==> [ []; [1]; [2]; [3]; [1;2]; [1;3]; [2;3]; [1;2;3] ]
//
let rec private _sort A B =
  match A, B with
  | []    , _      -> B               // end of list A : ret B
  | _     , []     -> A               // end of list B : ret A
  | e1::r1, e2::_  when (size e1 < size e2) ||
                        (not (size e1 < size e2) &&
                         not (size e2 < size e1) &&
                         e1 < e2)
                   -> e1::_sort r1 B  // prepend A's element
  | _     , e2::r2 -> e2::_sort A r2  // prepend B's element

let rec private _powerset x S =
  match S with
  | []   -> []                     // end of list : ret empty list
  | e::r -> (x::e)::_powerset x r  // prepend x to e

let rec powerset S =
  match S with
  | []   -> [[]]                       // end of list : ret [[]]
  | e::r -> let ps = powerset r        // recursive call
            _sort ps (_powerset e ps)  // sort lists
