//
// Shyam Patel (NetID: spate54)
// U. of Illinois, Chicago
// CS 341, Fall 2018
// Project #04: Sets in F#
//

module Tests

#light

open System
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type TestClass () =

  [<TestMethod>]
  member this.isEmpty_T01 () =
    let expected = true
    let actual = Set.isEmpty []
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.isEmpty_T02 () =
    let expected = false
    let actual = Set.isEmpty [1;2;3]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.isEmpty_T03 () =
    let expected = false
    let actual = Set.isEmpty ["apple";"cat";"dog"]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.isMember_T01 () =
    let expected = true
    let actual = Set.isMember "cat" ["apple";"cat";"dog"]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.isMember_T02 () =
    let expected = false
    let actual = Set.isMember 4 [1;2;3]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.isMember_T03 () =
    let expected = false
    let actual = Set.isMember "apple" []
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.isMember_T04 () =
    let expected = false
    let actual = Set.isMember "donkey" ["apple";"cat";"dog"]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.isMember_T05 () =
    let expected = true
    let actual = Set.isMember 1 [1;2;3]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.isMember_T06 () =
    let expected = true
    let actual = Set.isMember 3 [1;2;3]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.isMember_T07 () =
    let expected = false
    let actual = Set.isMember 7 [5;10;15]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.size_T01 () =
    let expected = 3
    let actual = Set.size ["apple";"cat";"dog"]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.size_T02 () =
    let expected = 8
    let actual = Set.size [1;2;3;4;5;6;7;8]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.size_T03 () =
    let expected = 4
    let actual = Set.size [10;20;30;40]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.size_T04 () =
    let expected = 3
    let actual = Set.size ["cat";"dog";"donkey"]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.size_T05 () =
    let expected = 8
    let actual = Set.size [[];[1];[2];[3];[1;2];[1;3];[2;3];[1;2;3]]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.size_T06 () =
    let expected = 6
    let actual = Set.size ["anaconda";"caterpillar";"flamingo";"python";"tiger";"zebra"]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.size_T07 () =
    let expected = 7
    let actual = Set.size ["nothing";"lasts";"forever";"or";"does";"it?";"IDK"]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.insert_T01 () =
    let expected = [1]
    let actual = Set.insert 1 []
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.insert_T02 () =
    let expected = [1;2;3]
    let actual = Set.insert 2 [1;3]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.insert_T03 () =
    let expected = ["apple";"cat";"dog"]
    let actual = Set.insert "cat" ["apple";"dog"]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.insert_T04 () =
    let expected = [1;2;3]
    let actual = Set.insert 3 [1;2]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.insert_T05 () =
    let expected = ["apple";"cat";"dog";"zebra"]
    let actual = Set.insert "zebra" ["apple";"cat";"dog"]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.insert_T06 () =
    let expected = ["anaconda";"apple";"cat";"dog";"zebra"]
    let actual = Set.insert "anaconda" ["apple";"cat";"dog";"zebra"]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.insert_T07 () =
    let expected = ["apple";"cat";"dog"]
    let actual = Set.insert "cat" ["apple";"cat";"dog"]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.insert_T08 () =
    let expected = ["apple";"cat";"dog"]
    let actual = Set.insert "dog" ["apple";"cat";"dog"]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.remove_T01 () =
    let expected = [1;3]
    let actual = Set.remove 2 [1;2;3]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.remove_T02 () =
    let expected = ["apple";"dog"]
    let actual = Set.remove "cat" ["apple";"cat";"dog"]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.remove_T03 () =
    let expected = [2;3]
    let actual = Set.remove 1 [1;2;3]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.remove_T04 () =
    let expected = List.empty<int>
    let actual = Set.remove 1 [1]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.remove_T05 () =
    let expected = List.empty<int>
    let actual = Set.remove 1 []
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.remove_T06 () =
    let expected = ["donkey";"zebra"]
    let actual = Set.remove "anaconda" ["anaconda";"donkey";"zebra"]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.remove_T07 () =
    let expected = ["anaconda";"donkey"]
    let actual = Set.remove "zebra" ["anaconda";"donkey";"zebra"]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.remove_T08 () =
    let expected = ["anaconda";"donkey";"zebra"]
    let actual = Set.remove "monkey" ["anaconda";"donkey";"zebra"]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.subset_T01 () =
    let expected = true
    let actual = Set.subset [1;2] [1;2;3]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.subset_T02 () =
    let expected = false
    let actual = Set.subset [1;4] [1;2;3]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.subset_T03 () =
    let expected = true
    let actual = Set.subset [3;5] [1;3;5;7]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.subset_T04 () =
    let expected = true
    let actual = Set.subset [1;3;5;7] [1;3;5;7]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.subset_T05 () =
    let expected = true
    let actual = Set.subset ["anaconda";"zebra"] ["anaconda";"donkey";"zebra"]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.subset_T06 () =
    let expected = false
    let actual = Set.subset ["anaconda";"flamingo"] ["anaconda";"donkey";"zebra"]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.subset_T07 () =
    let expected = true
    let actual = Set.subset [] []
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.subset_T08 () =
    let expected = true
    let actual = Set.subset [] ["anaconda"]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.equivalent_T01 () =
    let expected = false
    let actual = Set.equivalent [1;2] [1;2;3]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.equivalent_T02 () =
    let expected = true
    let actual = Set.equivalent [1;3;5;7] [1;3;5;7]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.equivalent_T03 () =
    let expected = true
    let actual = Set.equivalent [] []
    Assert.AreEqual(expected, actual)

  member this.equivalent_T04 () =
    let expected = false
    let actual = Set.equivalent [] [1]
    Assert.AreEqual(expected, actual)

  member this.equivalent_T05 () =
    let expected = false
    let actual = Set.equivalent [2;3] []
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.equivalent_T06 () =
    let expected = true
    let actual = Set.equivalent ["anaconda";"flamingo"] ["anaconda";"flamingo"]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.equivalent_T07 () =
    let expected = false
    let actual = Set.equivalent ["anaconda";"flamingo"] ["anaconda";"zebra"]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.equivalent_T08 () =
    let expected = false
    let actual = Set.equivalent ["2018";"2019"] ["10";"2018"]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.intersection_T01 () =
    let expected = [2;4]
    let actual = Set.intersection [1;2;3;4] [2;4]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.intersection_T02 () =
    let expected = List.empty<int>
    let actual = Set.intersection [1;2;3;4] [5;6]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.intersection_T03 () =
    let expected = [1;5]
    let actual = Set.intersection [1;3;5;7] [1;5;9]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.intersection_T04 () =
    let expected = ["anaconda";"zebra"]
    let actual = Set.intersection ["anaconda";"python";"zebra"] ["anaconda";"flamingo";"zebra"]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.intersection_T05 () =
    let expected = ["2018"]
    let actual = Set.intersection ["2018";"2019"] ["10";"2018"]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.intersection_T06 () =
    let expected = [[];[1];[2];[3];[1;2];[1;3];[2;3];[1;2;3]]
    let actual = Set.intersection [[];[1];[2];[3];[1;2];[1;3];[2;3];[1;2;3]] [[];[1];[2];[3];[4];[1;2];[1;3];[1;4];[2;3];[2;4];[3;4];[1;2;3];[1;2;4];[1;3;4];[2;3;4];[1;2;3;4]]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.intersection_T07 () =
    let expected = [6;7;8;9;10]
    let actual = Set.intersection [1;2;3;4;5;6;7;8;9;10] [6;7;8;9;10;11;12;13;14;15]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.union_T01 () =
    let expected = [1;2;3;4;5;6]
    let actual = Set.union [1;2;3;4] [2;5;6]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.union_T02 () =
    let expected = List.empty<int>
    let actual = Set.union List.empty<int> List.empty<int>
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.union_T03 () =
    let expected = [1;2;3]
    let actual = Set.union [1;2;3] []
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.union_T04 () =
    let expected = [4;5;6]
    let actual = Set.union [] [4;5;6]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.union_T05 () =
    let expected = ["anaconda";"flamingo";"python";"zebra"]
    let actual = Set.union ["anaconda";"python";"zebra"] ["anaconda";"flamingo";"zebra"]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.union_T06 () =
    let expected = [1;2;3;4;5;6;7;8;9;10;11;12;13;14;15]
    let actual = Set.union [1;2;3;4;5;6;7;8;9;10] [6;7;8;9;10;11;12;13;14;15]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.union_T07 () =
    let expected = [[];[1];[2];[3];[4];[1;2];[1;3];[1;4];[2;3];[2;4];[3;4];[1;2;3];[1;2;4];[1;3;4];[2;3;4];[1;2;3;4]]
    let actual = Set.union [[];[1];[2];[3];[1;2];[1;3];[2;3];[1;2;3]] [[];[1];[2];[3];[4];[1;2];[1;3];[1;4];[2;3];[2;4];[3;4];[1;2;3];[1;2;4];[1;3;4];[2;3;4];[1;2;3;4]]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.union_T08 () =
    let expected = [[];[1];[2];[3];[4];[1;2];[1;3];[1;4];[2;3];[2;4];[3;4];[1;2;3];[1;2;4];[1;3;4];[2;3;4];[1;2;3;4]]
    let actual = Set.union [[];[1];[2];[3];[4];[1;2];[1;3];[1;4];[2;3];[2;4];[3;4];[1;2;3];[1;2;4];[1;3;4];[2;3;4];[1;2;3;4]] [[];[1];[2];[3];[1;2];[1;3];[2;3];[1;2;3]]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.union_T09 () =
    let expected = ["anaconda";"caterpillar";"flamingo";"python";"zebra"]
    let actual = Set.union ["anaconda";"caterpillar";"python";"zebra"] ["anaconda";"flamingo";"zebra"]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.difference_T01 () =
    let expected = [1;3]
    let actual = Set.difference [1;2;3;4] [2;4]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.difference_T02 () =
    let expected = [1;2;3;4]
    let actual = Set.difference [1;2;3;4] List.empty<int>
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.difference_T03 () =
    let expected = List.empty<int>
    let actual = Set.difference List.empty<int> [1;2;3]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.difference_T04 () =
    let expected = [2;4;6]
    let actual = Set.difference [1;2;3;4;5;6] [1;3;5;8;9]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.difference_T05 () =
    let expected = ["caterpillar";"python"]
    let actual = Set.difference ["anaconda";"caterpillar";"python";"zebra"] ["anaconda";"flamingo";"zebra"]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.difference_T06 () =
    let expected = List.empty<string>
    let actual = Set.difference List.empty<string> ["anaconda";"flamingo";"zebra"]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.difference_T07 () =
    let expected = ["anaconda";"flamingo";"zebra"]
    let actual = Set.difference ["anaconda";"flamingo";"zebra"] List.empty<string>
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.difference_T08 () =
    let expected = [[4];[1;4];[2;4];[3;4];[1;2;4];[1;3;4];[2;3;4];[1;2;3;4]]
    let actual = Set.difference [[];[1];[2];[3];[4];[1;2];[1;3];[1;4];[2;3];[2;4];[3;4];[1;2;3];[1;2;4];[1;3;4];[2;3;4];[1;2;3;4]] [[];[1];[2];[3];[1;2];[1;3];[2;3];[1;2;3]]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.product_T01 () =
    let expected = [[1;3];[1;4];[2;3];[2;4]]
    let actual = Set.product [1;2] [3;4]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.product_T02 () =
    let expected = [[1;3];[2;3]]
    let actual = Set.product [1;2] [3]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.product_T03 () =
    let expected = [[1;5];[1;6];[1;7];[3;5];[3;6];[3;7]]
    let actual = Set.product [1;3] [5;6;7]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.product_T04 () =
    let expected = [List.empty<int>]
    let actual = Set.product List.empty<int> List.empty<int>
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.product_T05 () =
    let expected = [List.empty<int>]
    let actual = Set.product List.empty<int> [8;9;10]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.product_T06 () =
    let expected = [List.empty<int>]
    let actual = Set.product [5;6;7] List.empty<int>
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.product_T07 () =
    let expected = [["anaconda";"flamingo"];["anaconda";"python"];["anaconda";"tiger"];["anaconda";"zebra"];["caterpillar";"flamingo"];["caterpillar";"python"];["caterpillar";"tiger"];["caterpillar";"zebra"]]
    let actual = Set.product ["anaconda";"caterpillar"] ["flamingo";"python";"tiger";"zebra"]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.product_T08 () =
    let expected = [[1;5];[1;6];[1;7];[1;8];[2;5];[2;6];[2;7];[2;8];[3;5];[3;6];[3;7];[3;8];[4;5];[4;6];[4;7];[4;8]]
    let actual = Set.product [1;2;3;4] [5;6;7;8]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.powerset_T01 () =
    let expected = [[];[1];[2];[3];[1;2];[1;3];[2;3];[1;2;3]]
    let actual = Set.powerset [1;2;3]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.powerset_T02 () =
    let expected = [[];[1];[2];[3];[4];[1;2];[1;3];[1;4];[2;3];[2;4];[3;4];[1;2;3];[1;2;4];[1;3;4];[2;3;4];[1;2;3;4]]
    let actual = Set.powerset [1;2;3;4]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.powerset_T03 () =
    let expected = [[];[10]]
    let actual = Set.powerset [10]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.powerset_T04 () =
    let expected = [[];[10];[20];[10;20]]
    let actual = Set.powerset [10;20]
    Assert.AreEqual(expected, actual)

  [<TestMethod>]
  member this.powerset_T05 () =
    let expected = [[];[2];[4];[6];[8];[10];[2;4];[2;6];[2;8];[2;10];[4;6];[4;8];[4;10];[6;8];[6;10];[8;10];[2;4;6];[2;4;8];[2;4;10];[2;6;8];[2;6;10];[2;8;10];[4;6;8];[4;6;10];[4;8;10];[6;8;10];[2;4;6;8];[2;4;6;10];[2;4;8;10];[2;6;8;10];[4;6;8;10];[2;4;6;8;10]]
    let actual = Set.powerset [2;4;6;8;10]
    Assert.AreEqual(expected, actual)
