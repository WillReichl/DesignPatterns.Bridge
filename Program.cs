using NUnit.Framework;
using NUnit.Framework.Internal;

namespace BridgeExercise
{
    /**
     * You are given an example of an inheritance hierarchy which results in Cartesian-product duplication.
     * Please refactor this hierarchy, giving the base class Shape a constructor that takes an interface IRenderer
     * defined as:
     *
     * interface IRenderer
     * {
     *   string WhatToRenderAs { get; }
     * }
     * 
     * as well as VectorRenderer and RasterRenderer classes. Each implementer of the Shape abstract class should
     * have a constructor that takes an IRenderer such that, subsequently, each constructed object's ToString()
     * operates correctly, for example,
     *
     * new Triangle(new RasterRenderer()).ToString() // returns "Drawing Triangle as pixels"
     */

    public interface IRenderer
    {
        string WhatToRenderAs { get; }
    }

    public abstract class Shape
    {
        protected IRenderer renderer;

        protected Shape(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public string Name { get; set; }
        public override string ToString()
        {
            return $"Drawing {Name} as {renderer.WhatToRenderAs}";
        }
    }

    public class Triangle : Shape
    {
        public Triangle(IRenderer renderer) : base(renderer)
        {
            Name = "Triangle";
        }
    }

    public class Square : Shape
    {
        public Square(IRenderer renderer) : base(renderer)
        {
            Name = "Square";
        }
    }

    public class VectorRenderer : IRenderer
    {
        public string WhatToRenderAs => "lines";
    }

    public class RasterRenderer : IRenderer
    {
        public string WhatToRenderAs => "pixels";
    }

    // imagine VectorTriangle and RasterTriangle are here too

    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    namespace Coding.Exercise.Tests
    {
        [TestFixture]
        public class TestSuite
        {
            [Test]
            public void Test()
            {
                Assert.That(
                  new Square(new VectorRenderer()).ToString(),
                  Is.EqualTo("Drawing Square as lines"));
            }
        }
    }
}
