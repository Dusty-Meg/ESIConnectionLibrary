using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibrary.Tests.IntegrationTests
{
    public class DogmaIntegrationTests
    {
        [Fact]
        public void Attributes_successfully_returns_a_list_of_ints()
        {
            LatestDogmaEndpoints internalLatestDogma = new LatestDogmaEndpoints(string.Empty, true);

            IList<int> result = internalLatestDogma.Attributes();

            Assert.Equal(3, result.Count);
            Assert.Equal(1, result[0]);
            Assert.Equal(2, result[1]);
            Assert.Equal(3, result[2]);
        }

        [Fact]
        public async Task AttributesAsync_successfully_returns_a_list_of_ints()
        {
            LatestDogmaEndpoints internalLatestDogma = new LatestDogmaEndpoints(string.Empty, true);

            IList<int> result = await internalLatestDogma.AttributesAsync();

            Assert.Equal(3, result.Count);
            Assert.Equal(1, result[0]);
            Assert.Equal(2, result[1]);
            Assert.Equal(3, result[2]);
        }

        [Fact]
        public void Attribute_successfully_returns_a_V1DogmaAttribute()
        {
            LatestDogmaEndpoints internalLatestDogma = new LatestDogmaEndpoints(string.Empty, true);

            V1DogmaAttribute result = internalLatestDogma.Attribute(0);

            Assert.Equal(20, result.AttributeId);
            Assert.Equal(1, result.DefaultValue);
            Assert.Equal("Factor by which topspeed increases.", result.Description);
            Assert.Equal("Maximum Velocity Bonus", result.DisplayName);
            Assert.True(result.HighIsGood);
            Assert.Equal(1389, result.IconId);
            Assert.Equal("speedFactor", result.Name);
            Assert.True(result.Published);
            Assert.Equal(124, result.UnitId);
        }

        [Fact]
        public async Task AttributeAsync_successfully_returns_a_V1DogmaAttribute()
        {
            LatestDogmaEndpoints internalLatestDogma = new LatestDogmaEndpoints(string.Empty, true);

            V1DogmaAttribute result = await internalLatestDogma.AttributeAsync(0);

            Assert.Equal(20, result.AttributeId);
            Assert.Equal(1, result.DefaultValue);
            Assert.Equal("Factor by which topspeed increases.", result.Description);
            Assert.Equal("Maximum Velocity Bonus", result.DisplayName);
            Assert.True(result.HighIsGood);
            Assert.Equal(1389, result.IconId);
            Assert.Equal("speedFactor", result.Name);
            Assert.True(result.Published);
            Assert.Equal(124, result.UnitId);
        }

        [Fact]
        public void DynamicItem_successfully_returns_a_V1DogmaDynamicItem()
        {
            LatestDogmaEndpoints internalLatestDogma = new LatestDogmaEndpoints(string.Empty, true);

            V1DogmaDynamicItem result = internalLatestDogma.DynamicItem(0, 0);

            Assert.Equal(2112625428, result.CreatedBy);

            Assert.Single(result.DogmaAttributes);
            Assert.Equal(9, result.DogmaAttributes[0].AttributeId);
            Assert.Equal(350, result.DogmaAttributes[0].Value);

            Assert.Single(result.DogmaEffects);
            Assert.Equal(508, result.DogmaEffects[0].EffectId);
            Assert.False(result.DogmaEffects[0].IsDefault);

            Assert.Equal(47845, result.MutatorTypeId);
            Assert.Equal(33103, result.SourceTypeId);
        }

        [Fact]
        public async Task DynamicItemAsync_successfully_returns_a_V1DogmaDynamicItem()
        {
            LatestDogmaEndpoints internalLatestDogma = new LatestDogmaEndpoints(string.Empty, true);

            V1DogmaDynamicItem result = await internalLatestDogma.DynamicItemAsync(0, 0);

            Assert.Equal(2112625428, result.CreatedBy);

            Assert.Single(result.DogmaAttributes);
            Assert.Equal(9, result.DogmaAttributes[0].AttributeId);
            Assert.Equal(350, result.DogmaAttributes[0].Value);

            Assert.Single(result.DogmaEffects);
            Assert.Equal(508, result.DogmaEffects[0].EffectId);
            Assert.False(result.DogmaEffects[0].IsDefault);

            Assert.Equal(47845, result.MutatorTypeId);
            Assert.Equal(33103, result.SourceTypeId);
        }

        [Fact]
        public void Effects_successfully_returns_a_list_of_ints()
        {
            LatestDogmaEndpoints internalLatestDogma = new LatestDogmaEndpoints(string.Empty, true);

            IList<int> result = internalLatestDogma.Effects();

            Assert.Equal(3, result.Count);
            Assert.Equal(1, result[0]);
            Assert.Equal(2, result[1]);
            Assert.Equal(3, result[2]);
        }

        [Fact]
        public async Task EffectsAsync_successfully_returns_a_list_of_ints()
        {
            LatestDogmaEndpoints internalLatestDogma = new LatestDogmaEndpoints(string.Empty, true);

            IList<int> result = await internalLatestDogma.EffectsAsync();

            Assert.Equal(3, result.Count);
            Assert.Equal(1, result[0]);
            Assert.Equal(2, result[1]);
            Assert.Equal(3, result[2]);
        }

        [Fact]
        public void Effect_successfully_returns_a_V2DogmaEffect()
        {
            LatestDogmaEndpoints internalLatestDogma = new LatestDogmaEndpoints(string.Empty, true);

            V2DogmaEffect result = internalLatestDogma.Effect(0);

            Assert.Equal("Requires a high power slot.", result.Description);
            Assert.Equal("High power", result.DisplayName);
            Assert.Equal(0, result.EffectCategory);
            Assert.Equal(12, result.EffectId);
            Assert.Equal(293, result.IconId);
            Assert.Equal("hiPower", result.Name);
            Assert.Equal(131, result.PostExpression);
            Assert.Equal(131, result.PreExpression);
            Assert.True(result.Published);
        }

        [Fact]
        public async Task EffectAsync_successfully_returns_a_V2DogmaEffect()
        {
            LatestDogmaEndpoints internalLatestDogma = new LatestDogmaEndpoints(string.Empty, true);

            V2DogmaEffect result = await internalLatestDogma.EffectAsync(0);

            Assert.Equal("Requires a high power slot.", result.Description);
            Assert.Equal("High power", result.DisplayName);
            Assert.Equal(0, result.EffectCategory);
            Assert.Equal(12, result.EffectId);
            Assert.Equal(293, result.IconId);
            Assert.Equal("hiPower", result.Name);
            Assert.Equal(131, result.PostExpression);
            Assert.Equal(131, result.PreExpression);
            Assert.True(result.Published);
        }
    }
}
