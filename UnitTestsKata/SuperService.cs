using System.Collections.Generic;
using System.Configuration;
using UnitTestsKata.Services;

namespace UnitTestsKata
{
    //- Can you please make sure that we're not adding invalid LegalEntities to our system?
    //- Hey dumbass! I've been receiving two idential notification e-mails every morning... please, fix that!
    //- Dear IT Nerd, please stop playing DOTA and tell me why I didn't receive any notification email this morning... 
    //    (insert log)

    public class SuperService
    {
        private readonly IAmAnInputService _inputService;
        private readonly IKnowHowToTransformData _transformService;
        private readonly IKnowHowToValidateLegalEntities _legalEntitiesValidator;
        private readonly IRepository<LegalEntity> _legalEntitiesRepository;
        private readonly IKnowHowToTalkToTheTaskManagerApp _taskManager;


        public SuperService(IAmAnInputService inputService,
                            IKnowHowToTransformData transformService,
                            IKnowHowToValidateLegalEntities legalEntitiesValidator,
                            IRepository<LegalEntity> legalEntitiesRepository,
                            IKnowHowToTalkToTheTaskManagerApp taskManager)
        {
            _inputService = inputService;
            _transformService = transformService;
            _legalEntitiesValidator = legalEntitiesValidator;
            _legalEntitiesRepository = legalEntitiesRepository;
            _taskManager = taskManager;
        }

        public void Run()
        {
            var data = _inputService.ReadFiles();
            var legalEntities = _transformService.Transform(data);
            var validationResult = _legalEntitiesValidator.Validate(legalEntities);
            _legalEntitiesRepository.BulkInsert(legalEntities);

            _taskManager.StartJob("postEtl");

            var emails = ReadUserFromConfig();
            NotifyUsers(emails);
        }

        private void NotifyUsers(IList<string> emails)
        {

        }

        private IList<string> ReadUserFromConfig()
        {
            return ConfigurationManager.AppSettings["UserEmailList"].Split(';');

        }
    }
}
