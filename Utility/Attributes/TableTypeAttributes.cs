namespace Library.Utility.Attributes
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class TableTypeAttribute : Attribute
    {
        // This is a positional argument
        public TableTypeAttribute()
        {
            
        }

    }
}