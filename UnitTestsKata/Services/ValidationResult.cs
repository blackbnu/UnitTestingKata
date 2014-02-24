using System;
using System.Collections.Generic;

namespace UnitTestsKata.Services
{
    public class ValidationResult
    {
        public Dictionary<Guid, LegalEntityValidationStatus> Result { get; set; }
    }

    public enum LegalEntityValidationStatus
    {
        Valid,
        Invalid
    }
}