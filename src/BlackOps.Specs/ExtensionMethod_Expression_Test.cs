namespace BlackOps.Specs
{
    using System;
    using System.Linq.Expressions;
    using NUnit.Framework;

    [TestFixture]
    public class ExtensionMethod_Expression_Test
    {
        [Test]
        public void NAME() //convert b.Bill().Queue() to 'bob/bill/queue'
        {

            Expression<Action<FeatureRoot>> xx = b => b.Bill().Queue();

            MethodCallExpression m = (MethodCallExpression)xx.Body;
            string v = m.ToString();
            v = v.Replace("(", "");
            v = v.Replace(")", "");
            v = v.Replace(".", "/");
            v = "/" + v;
            Console.WriteLine(v);
        }
    }

    public class FeatureRoot
    {
        
    }
    public static class MyFeatureExtensions
    {
        public static BillFeatures Bill(this FeatureRoot featureRoot)
        {
            return null;
        }
    }
    public interface BillFeatures
    {
        void Queue();
    }
}