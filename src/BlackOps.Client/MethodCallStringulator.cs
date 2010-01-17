namespace BlackOps.Client
{
    using System;
    using System.Linq.Expressions;

    public class MethodCallStringulator
    {
        public static string Convert(Expression<Action<Features>> features)
        {
            MethodCallExpression m = (MethodCallExpression)features.Body;
            string v = m.ToString();
            v = v.Replace("(", "");
            v = v.Replace(")", "");
            v = v.Replace(".", "/");
            v = "/" + v;
            return v;
        }
        public static string Convert(Expression<Action<Statuses>> features)
        {
            MethodCallExpression m = (MethodCallExpression)features.Body;
            string v = m.ToString();
            v = v.Replace("(", "");
            v = v.Replace(")", "");
            v = v.Replace(".", "/");
            v = "/" + v;
            return v;
        }
    }
}