using System.Collections.Generic;
using System.Configuration;
using UnitTestsKata.Services;

namespace UnitTestsKata
{
    using UnitTestsKata.FileModel;

    //- Can you please make sure that we're not adding invalid LegalEntities to our system?
    //- I've been receiving two idential notification e-mails every morning... would you please fix that?
    //- I didn't receive any notification email this morning! 
    //  If something went wrong with the SuperService, I wanna be notified! 
    //    After a quick investigation, we found this execution log:
         //System.IO.FileNotFoundException : Unable to find the specified file.
         //at InputService.ReadFiles() 
         //at UnitTestsKata.SuperService.Run() 
         //at Program.Main()  

    public class SuperService
    {
        private readonly IAmAnInputService _inputService;
        private readonly IKnowHowToTransformData _transformService;
        private readonly IKnowHowToValidateLegalEntities _legalEntitiesValidator;
        private readonly IRepository<LegalEntity> _legalEntitiesRepository;
        private readonly IKnowHowToTalkToTheTaskManagerApp _taskManager;
        private readonly IKnowHowToSendEmails _emailService;

        public SuperService(IAmAnInputService inputService,
                            IKnowHowToTransformData transformService,
                            IKnowHowToValidateLegalEntities legalEntitiesValidator,
                            IRepository<LegalEntity> legalEntitiesRepository,
                            IKnowHowToTalkToTheTaskManagerApp taskManager,
                            IKnowHowToSendEmails emailService)
        {
            _inputService = inputService;
            _transformService = transformService;
            _legalEntitiesValidator = legalEntitiesValidator;
            _legalEntitiesRepository = legalEntitiesRepository;
            _taskManager = taskManager;
            _emailService = emailService;
        }

        public void Run()
        {
            var data = _inputService.ReadFiles();
            var legalEntities = _transformService.Transform(data);
            _legalEntitiesValidator.Validate(legalEntities);
            _legalEntitiesRepository.BulkInsert(legalEntities);

            _taskManager.StartJob("postEtl");

            var emails = ReadUserFromConfig();
            this._emailService.SendSucceededNotification(emails);
        }

        private IList<string> ReadUserFromConfig()
        {
            return ConfigurationManager.AppSettings["UserEmailList"].Split(';');

        }
    }
}
