using System.Collections.Generic;

namespace UnitTestsKata.Services
{
    public interface IKnowHowToTransformData
    {
        IList<LegalEntity> Transform(FileDataModel data);
    }
}