using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestDogmaEndpoints : ILatestDogmaEndpoints
    {
        private readonly IInternalLatestDogma _internalLatestDogma;

        public LatestDogmaEndpoints(string userAgent, bool testing = false)
        {
            _internalLatestDogma = new InternalLatestDogma(null, userAgent, testing);
        }

        public IList<int> Attributes()
        {
            return _internalLatestDogma.Attributes();
        }

        public async Task<IList<int>> AttributesAsync()
        {
            return await _internalLatestDogma.AttributesAsync();
        }

        public V1DogmaAttribute Attribute(int attributeId)
        {
            return _internalLatestDogma.Attribute(attributeId);
        }

        public async Task<V1DogmaAttribute> AttributeAsync(int attributeId)
        {
            return await _internalLatestDogma.AttributeAsync(attributeId);
        }

        public V1DogmaDynamicItem DynamicItem(int typeId, long itemId)
        {
            return _internalLatestDogma.DynamicItem(typeId, itemId);
        }

        public async Task<V1DogmaDynamicItem> DynamicItemAsync(int typeId, long itemId)
        {
            return await _internalLatestDogma.DynamicItemAsync(typeId, itemId);
        }

        public IList<int> Effects()
        {
            return _internalLatestDogma.Effects();
        }

        public async Task<IList<int>> EffectsAsync()
        {
            return await _internalLatestDogma.EffectsAsync();
        }

        public V2DogmaEffect Effect(int effectId)
        {
            return _internalLatestDogma.Effect(effectId);
        }

        public async Task<V2DogmaEffect> EffectAsync(int effectId)
        {
            return await _internalLatestDogma.EffectAsync(effectId);
        }
    }
}
