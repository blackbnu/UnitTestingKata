namespace UnitTestsKata
{
    using System.Collections.Generic;

    public interface IKnowHowToTransformData
    {
        IList<LegalEntity> Transform(FileDataModel data);
    }
}