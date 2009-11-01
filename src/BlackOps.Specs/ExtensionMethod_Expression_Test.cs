namespace BlackOps.Specs
{
    using System;
    using System.Linq.Expressions;
    using NUnit.Framework;

    [TestFixture]
    public class ExtensionMethod_Expression_Test
    {
        [Test]
        public void NAME()
        {
            Expression<Action<Bob>> xx = b => b.Bill().Queue();

            MethodCallExpression m = (MethodCallExpression)xx.Body;

            Console.WriteLine(m);
        }
    }

    public class Bob
    {
        
    }
    public static class BobExt
    {
        public static BillFeatures Bill(this Bob bob)
        {
            return null;
        }
    }
    public interface BillFeatures
    {
        void Queue();
    }
}