namespace Goalify.Common.Helper
{
    public static class ObjectVerification
    {
        public static string GetNullProperties(object obj)
        {
            if (obj == null)
                return "Object is null";

            var nullProps = obj
                .GetType()
                .GetProperties()
                .Where(p => p.CanRead && p.GetValue(obj) == null)
                .Select(p => p.Name)
                .ToList();

            if (!nullProps.Any())
                return string.Empty;

            return "Null properties: " + string.Join(", ", nullProps);
        }
    }
}
