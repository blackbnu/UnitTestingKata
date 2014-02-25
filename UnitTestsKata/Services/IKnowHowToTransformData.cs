using System.Collections.Generic;

namespace UnitTestsKata.Services
{
    using UnitTestsKata.FileModel;

    public interface IKnowHowToTransformData
    {
        IList<LegalEntity> Transform(FileDataModel data);
    }
}