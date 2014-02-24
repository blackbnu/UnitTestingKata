namespace UnitTestsKata
{
    using System.Collections.Generic;

    using UnitTestsKata.Services;

    public interface IKnowHowToValidateLegalEntities
    {
        ValidationResult Validate(IList<LegalEntity> legalEntities);
    }
}