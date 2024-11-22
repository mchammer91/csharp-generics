using System.Text.Json;

namespace WiredBrainCoffee.StorageApp.Entities;

public static class EntityExtensions
{
    /*
     * Add where clause so that the method is only available to objects from classes that implement IEntity 
     */
    public static T? Copy<T>(this T itemToCopy) where T : IEntity
    {
        var json = JsonSerializer.Serialize<T>(itemToCopy);
        return JsonSerializer.Deserialize<T>(json);
    }
}