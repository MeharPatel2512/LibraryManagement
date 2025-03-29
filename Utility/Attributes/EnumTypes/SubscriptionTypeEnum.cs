using System.ComponentModel;

namespace Library.Utility.Attributes.EnumTypes
{
    public enum SubscriptionTypeEnum
    {
        [Description("1 Week")]
        OneWeek = 1,

        [Description("15 Days")]
        FifteenDays = 2,

        [Description("1 Month")]
        OneMonth = 3,

        [Description("3 Month")]
        ThreeMonths = 4,

        [Description("6 Month")]
        SixMonths = 5,

        [Description("1 Year")]
        OneYear = 6
    }
}