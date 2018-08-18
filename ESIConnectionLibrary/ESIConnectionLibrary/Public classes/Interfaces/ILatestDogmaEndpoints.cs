using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestDogmaEndpoints
    {
        V1DogmaAttribute Attribute(int attributeId);
        Task<V1DogmaAttribute> AttributeAsync(int attributeId);
        IList<int> Attributes();
        Task<IList<int>> AttributesAsync();
        V1DogmaDynamicItem DynamicItem(int typeId, long itemId);
        Task<V1DogmaDynamicItem> DynamicItemAsync(int typeId, long itemId);
        V2DogmaEffect Effect(int effectId);
        Task<V2DogmaEffect> EffectAsync(int effectId);
        IList<int> Effects();
        Task<IList<int>> EffectsAsync();
    }
}