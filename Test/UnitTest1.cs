using ConsoleApp2;
using System;
using Xunit;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Test tree:
            // 
            // 1
            // +-2
            //   +-3
            //   +-4
            // +-5
            //   +-6
            //   +-7
            //
            var lastNode = new Node(7);
            var tree = new Node(
                1,
                new Node(
                    2,
                    new Node(3),
                    new Node(4)),
                new Node(
                    5,
                    new Node(6),
                    lastNode));

            // Expected output:
            //
            // 7
            // 6
            // 5
            // 4
            // 3
            // 2
            // 1
            //
            var n = lastNode;
            while (n != null)
            {
                Console.WriteLine(n.Data);
                n = n.Previous();
            }

            // Test
            //
            n = lastNode;
            Assert.Equal(7, n.Data);
            n = n.Previous();
            Assert.Equal(6, n.Data);
            n = n.Previous();
            Assert.Equal(5, n.Data);
            n = n.Previous();
            Assert.Equal(4, n.Data);
            n = n.Previous();
            Assert.Equal(3, n.Data);
            n = n.Previous();
            Assert.Equal(2, n.Data);
            n = n.Previous();
            Assert.Equal(1, n.Data);
            n = n.Previous();
            Assert.Null(n);
        }


        [Fact]
        public void Test2()
        {
            // Test tree:
            // 
            // 1
            // +-2
            // +-3
            // +-4

            //
            var lastNode = new Node(4);
            var root = new Node(
               1,
               new Node(2),
               new Node(3),
              lastNode);

            // Expected output:
            //
            // 4
            // 3
            // 2
            // 1
     
            //
            var n = lastNode;
            while (n != null)
            {
                Console.WriteLine(n.Data);
                n = n.Previous();
            }

            // Test
            //
            n = lastNode;
            Assert.Equal(4, n.Data);
            n = n.Previous();
            Assert.Equal(3, n.Data);
            n = n.Previous();
            Assert.Equal(2, n.Data);
            n = n.Previous();
            Assert.Equal(1, n.Data);
            n = n.Previous();
            Assert.Null(n);
        }



    }
}
