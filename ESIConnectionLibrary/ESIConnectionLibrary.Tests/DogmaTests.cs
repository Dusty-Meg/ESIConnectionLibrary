using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;
using Moq;
using Xunit;

namespace ESIConnectionLibrary.Tests
{
    public class DogmaTests
    {
        [Fact]
        public void Attributes_successfully_returns_a_list_of_ints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  1,\r\n  2,\r\n  3\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestDogma internalLatestDogma = new InternalLatestDogma(mockedWebClient.Object, string.Empty);

            IList<int> result = internalLatestDogma.Attributes();

            Assert.Equal(3, result.Count);
            Assert.Equal(1, result[0]);
            Assert.Equal(2, result[1]);
            Assert.Equal(3, result[2]);
        }

        [Fact]
        public async Task AttributesAsync_successfully_returns_a_list_of_ints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  1,\r\n  2,\r\n  3\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestDogma internalLatestDogma = new InternalLatestDogma(mockedWebClient.Object, string.Empty);

            IList<int> result = await internalLatestDogma.AttributesAsync();

            Assert.Equal(3, result.Count);
            Assert.Equal(1, result[0]);
            Assert.Equal(2, result[1]);
            Assert.Equal(3, result[2]);
        }

        [Fact]
        public void Attribute_successfully_returns_a_V1DogmaAttribute()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"attribute_id\": 20,\r\n  \"default_value\": 1,\r\n  \"description\": \"Factor by which topspeed increases.\",\r\n  \"display_name\": \"Maximum Velocity Bonus\",\r\n  \"high_is_good\": true,\r\n  \"icon_id\": 1389,\r\n  \"name\": \"speedFactor\",\r\n  \"published\": true,\r\n  \"unit_id\": 124\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestDogma internalLatestDogma = new InternalLatestDogma(mockedWebClient.Object, string.Empty);

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
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"attribute_id\": 20,\r\n  \"default_value\": 1,\r\n  \"description\": \"Factor by which topspeed increases.\",\r\n  \"display_name\": \"Maximum Velocity Bonus\",\r\n  \"high_is_good\": true,\r\n  \"icon_id\": 1389,\r\n  \"name\": \"speedFactor\",\r\n  \"published\": true,\r\n  \"unit_id\": 124\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestDogma internalLatestDogma = new InternalLatestDogma(mockedWebClient.Object, string.Empty);

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
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"created_by\": 2112625428,\r\n  \"dogma_attributes\": [\r\n    {\r\n      \"attribute_id\": 9,\r\n      \"value\": 350\r\n    }\r\n  ],\r\n  \"dogma_effects\": [\r\n    {\r\n      \"effect_id\": 508,\r\n      \"is_default\": false\r\n    }\r\n  ],\r\n  \"mutator_type_id\": 47845,\r\n  \"source_type_id\": 33103\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestDogma internalLatestDogma = new InternalLatestDogma(mockedWebClient.Object, string.Empty);

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
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"created_by\": 2112625428,\r\n  \"dogma_attributes\": [\r\n    {\r\n      \"attribute_id\": 9,\r\n      \"value\": 350\r\n    }\r\n  ],\r\n  \"dogma_effects\": [\r\n    {\r\n      \"effect_id\": 508,\r\n      \"is_default\": false\r\n    }\r\n  ],\r\n  \"mutator_type_id\": 47845,\r\n  \"source_type_id\": 33103\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestDogma internalLatestDogma = new InternalLatestDogma(mockedWebClient.Object, string.Empty);

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
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  1,\r\n  2,\r\n  3\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestDogma internalLatestDogma = new InternalLatestDogma(mockedWebClient.Object, string.Empty);

            IList<int> result = internalLatestDogma.Effects();

            Assert.Equal(3, result.Count);
            Assert.Equal(1, result[0]);
            Assert.Equal(2, result[1]);
            Assert.Equal(3, result[2]);
        }

        [Fact]
        public async Task EffectsAsync_successfully_returns_a_list_of_ints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  1,\r\n  2,\r\n  3\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestDogma internalLatestDogma = new InternalLatestDogma(mockedWebClient.Object, string.Empty);

            IList<int> result = await internalLatestDogma.EffectsAsync();

            Assert.Equal(3, result.Count);
            Assert.Equal(1, result[0]);
            Assert.Equal(2, result[1]);
            Assert.Equal(3, result[2]);
        }

        [Fact]
        public void Effect_successfully_returns_a_V2DogmaEffect()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"description\": \"Requires a high power slot.\",\r\n  \"display_name\": \"High power\",\r\n  \"effect_category\": 0,\r\n  \"effect_id\": 12,\r\n  \"icon_id\": 293,\r\n  \"name\": \"hiPower\",\r\n  \"post_expression\": 131,\r\n  \"pre_expression\": 131,\r\n  \"published\": true\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestDogma internalLatestDogma = new InternalLatestDogma(mockedWebClient.Object, string.Empty);

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
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"description\": \"Requires a high power slot.\",\r\n  \"display_name\": \"High power\",\r\n  \"effect_category\": 0,\r\n  \"effect_id\": 12,\r\n  \"icon_id\": 293,\r\n  \"name\": \"hiPower\",\r\n  \"post_expression\": 131,\r\n  \"pre_expression\": 131,\r\n  \"published\": true\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestDogma internalLatestDogma = new InternalLatestDogma(mockedWebClient.Object, string.Empty);

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
