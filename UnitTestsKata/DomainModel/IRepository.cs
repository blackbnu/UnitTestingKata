namespace UnitTestsKata
{
    using System.Collections.Generic;

    public interface IRepository<T>
    {
        void BulkInsert(IList<LegalEntity> legalEntities);
    }
}