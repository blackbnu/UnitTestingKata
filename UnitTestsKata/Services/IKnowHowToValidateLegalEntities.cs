namespace UnitTestsKata
{
    using System.Collections.Generic;

    public interface IKnowHowToValidateLegalEntities
    {
        ValidationResult Validate(IList<LegalEntity> legalEntities);
    }
}