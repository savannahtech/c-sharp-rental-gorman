using Bogus;
using Data.Entities;

namespace Unit.Test.MockData;

public static class PropertyData
{
    public static Property GetProperty()
    {
        var data = new Faker<Property>();
        return data;
    }
}