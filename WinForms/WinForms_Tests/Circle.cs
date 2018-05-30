using System;
using System.Drawing;
using WinForms.Shapes;
using Xunit;

namespace WinForms_Tests
{
    public class Tests
    {
        [Fact]
        public void RadiusTest1()
        {
            Circle circle = new Circle(new Point(1, 1), 4);
            const double expected = 4;

            double actual = circle.Radius;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RadiusTest2()
        {
            Circle circle = new Circle(new Point(1, 1), 2);
            const double expected = 2;

            var actual = Math.Round((double) circle.Radius, 5);

            Assert.Equal(expected, actual);
        }
    }
}