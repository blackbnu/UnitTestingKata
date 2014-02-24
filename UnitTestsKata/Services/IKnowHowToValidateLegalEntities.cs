using System.Collections.Generic;

namespace UnitTestsKata.Services
{
    public interface IKnowHowToValidateLegalEntities
    {
        ValidationResult Validate(IList<LegalEntity> legalEntities);
    }
}