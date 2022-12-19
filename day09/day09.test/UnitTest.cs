namespace day09.test
{
    using day09;
    using System.Security.Cryptography.X509Certificates;

    public class UnitTest
    {
        public static IEnumerable<object[]> Parameters
        {
            get
            {
                //test1
                yield return new object[] { new Position(0,0), new Position(0, 1), true };
                //test2
                yield return new object[] { new Position(0,0), new Position(0, 2), false };
                //test3
                yield return new object[] { new Position(0, 0), new Position(1, 1), true };
            }
        }

        [Theory]
        [MemberData(nameof(Parameters))]
        public void TestTouching3(Position a, Position b, bool expectedResult)
        {
            Assert.Equal(expectedResult, a.Touching(b));
        }

        [Theory]
        [InlineData(0, 0, 0, 1, true)]
        [InlineData(0, 0, 0, 2, false)]
        [InlineData(0, 0, 1, 1, true)]

        public void TestTouching2(int a1, int a2, int b1, int b2, bool expectedResult)
        {
            Position a = new Position(a1, a2);
            Position b = new Position(b1, b2);

            Assert.Equal(expectedResult, a.Touching(b));
        }


        public static IEnumerable<object[]> Diagonal
        {
            get
            {
                //test1
                yield return new object[] { new Position(0, 0), new Position(1, 1), true };
                //test2
                yield return new object[] { new Position(0, 0), new Position(0, 1), false };
                //test3
                yield return new object[] { new Position(0, 0), new Position(1, 0), false };
                //test3
                yield return new object[] { new Position(1, 1), new Position(2, 2), true };
                //test3
                yield return new object[] { new Position(1, 1), new Position(2, 1), false };
            }
        }

        [Theory]
        [MemberData(nameof(Diagonal))]
        public void TestDiagonal(Position a, Position b, bool expectedResult)
        {
            Assert.Equal(expectedResult, a.Diagonal(b));
        }

        public static IEnumerable<object[]> MyMovementsUp
        {
            get
            {
                //test1
                yield return new object[] {
                    new RopeMovements(new Position(3, 3), new Position(3, 3)), // initial position
                    new Position(2, 3), //expected position for H
                    new Position(3, 3)  //expected position for T
                };

                //test2
                yield return new object[] {
                    new RopeMovements(new Position(1, 3), new Position(2, 3)), // initial position
                    new Position(0, 3), //expected position for H
                    new Position(1, 3)  //expected position for T
                };

                //test3 - diagonal
                yield return new object[] {
                    new RopeMovements(new Position(1, 1), new Position(2, 2)), // initial position
                    new Position(0, 1), //expected position for H
                    new Position(1, 1)  //expected position for T
                };

                //test4 - diagonal
                yield return new object[] {
                    new RopeMovements(new Position(1, 1), new Position(2, 2)), // initial position
                    new Position(0, 1), //expected position for H
                    new Position(1, 1)  //expected position for T
                };

                //test5 - diagonal
                yield return new object[] {
                    new RopeMovements(new Position(2, 2), new Position(3, 1)), // initial position
                    new Position(1, 2), //expected position for H
                    new Position(2, 2)  //expected position for T
                };
            }
        }


        [Theory]
        [MemberData(nameof(MyMovementsUp))]
        public void TestMovingUp(RopeMovements rm, Position expectedPositionH, Position expectedPositionT)
        {
            rm.MoveH(Movs.Up);         
            Assert.Equal(expectedPositionH, rm.H);
            Assert.Equal(expectedPositionT, rm.T);

        }

        public static IEnumerable<object[]> MyMovementsRight
        {
            get
            {
                //test1 
                yield return new object[] {
                    new RopeMovements(new Position(4, 0), new Position(4, 0)), // initial position
                    new Position(4, 1), //expected position for H
                    new Position(4, 0)  //expected position for T
                };

                //test2
                yield return new object[] {
                    new RopeMovements(new Position(4, 1), new Position(4, 0)), // initial position
                    new Position(4, 2), //expected position for H
                    new Position(4, 1)  //expected position for T
                };

                //test3
                yield return new object[] {
                    new RopeMovements(new Position(4, 2), new Position(4, 1)), // initial position
                    new Position(4, 3), //expected position for H
                    new Position(4, 2)  //expected position for T
                };

                //test4
                yield return new object[] {
                    new RopeMovements(new Position(4, 3), new Position(4, 2)), // initial position
                    new Position(4, 4), //expected position for H
                    new Position(4, 3)  //expected position for T
                };

                //test5 - diagonal
                yield return new object[] {
                    new RopeMovements(new Position(1, 2), new Position(0, 2)), // initial position
                    new Position(1, 3), //expected position for H
                    new Position(0, 2)  //expected position for T
                };
            }
        }


        [Theory]
        [MemberData(nameof(MyMovementsRight))]
        public void TestMovingRight(RopeMovements rm, Position expectedPositionH, Position expectedPositionT)
        {
            rm.MoveH(Movs.Right);
            Assert.Equal(expectedPositionH, rm.H);
            Assert.Equal(expectedPositionT, rm.T);

        }

        public static IEnumerable<object[]> MyMovementsDown
        {
            get
            {
                //test1 
                yield return new object[] {
                    new RopeMovements(new Position(0, 1), new Position(0, 2)), // initial position
                    new Position(1, 1), //expected position for H
                    new Position(0, 2)  //expected position for T
                };

                //test2
                yield return new object[] {
                    new RopeMovements(new Position(1, 5), new Position(1, 4)), // initial position
                    new Position(2, 5), //expected position for H
                    new Position(1, 4)  //expected position for T
                };
            }
        }

        [Theory]
        [MemberData(nameof(MyMovementsDown))]
        public void TestMovingBottom(RopeMovements rm, Position expectedPositionH, Position expectedPositionT)
        {
            rm.MoveH(Movs.Down);
            Assert.Equal(expectedPositionH, rm.H);
            Assert.Equal(expectedPositionT, rm.T);

        }

        public static IEnumerable<object[]> MyMovementsLeft
        {
            get
            {
                //test1 
                yield return new object[] {
                    new RopeMovements(new Position(2, 5), new Position(1, 4)), // initial position
                    new Position(2, 4), //expected position for H
                    new Position(1, 4)  //expected position for T
                };

                //test2
                yield return new object[] {
                    new RopeMovements(new Position(2, 3), new Position(1,4)), // initial position
                    new Position(2, 2), //expected position for H
                    new Position(2, 3)  //expected position for T
                };
            }
        }

        [Theory]
        [MemberData(nameof(MyMovementsLeft))]
        public void TestMovingLeft(RopeMovements rm, Position expectedPositionH, Position expectedPositionT)
        {
            rm.MoveH(Movs.Left);
            Assert.Equal(expectedPositionH, rm.H);
            Assert.Equal(expectedPositionT, rm.T);

        }

        [Fact]
        public void TestParse()
        {
            RopeMovements rm = new RopeMovements(new Position(10, 0), new Position(10, 0));
            rm.ReadAndParseMovementFile("data/test.txt");
        }

    }
}