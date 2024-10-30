using DeliveryService.InputDatas.Interfaces;
using DeliveryService.Logger.Interface.InLogger;
using DeliveryService.Logger.Interface.OutLogger;
using DeliveryService.Models;
using DeliveryService.Service.Implementations;
using DeliveryService.User;
using DeliveryService.User.UserProtocolService;
using DeliveryService.Validation;
using DeliveryService.Validation.Interfaces;

namespace DeliveryService
{
    class Program
    {
        private static Logger.Implementation.Logger _logger;
        private static ICreatingValidator _creatingValidator = new UserInputValidator();
        private static IUpdatValidator _updateValidator = new UserInputValidator();
        private static IFilteringValidator _filteringValidator = new UserInputValidator();
        private static IFilterParams _filterParams;
        private static IOrderCreate _orderCreate;
        private static IOrderUpdate _orderUpdate;
        private static FilterParamsProtocol _filterParamsProtocol;
        private static CreatingProtocol _creationProtocol;
        private static UpdatingProtocol _updateProtocol;
        private static UserProtocol _userProtocol;
        private static IInUpdateModel _inUpdateModel;
        private static IInFilterModel _inFilterModel;
        private static IInCreateModel _inCreateModel;
        private static IOutCreateModel _outCreate;
        private static IOutUpdateModel _outUpdate;
        private static IOutFilterModel _outFilter;
        static void Main(string[] args)
        {
            Initialize();
        }
        private static void Initialize()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

             _logger = new Logger.Implementation.Logger();

            _filteringValidator = new UserInputValidator();

            _updateValidator = new UserInputValidator();

            _creatingValidator = new UserInputValidator();

            _inCreateModel = new InModel();

            _inFilterModel = new InModel();

            _inUpdateModel = new InModel();
           
            _outCreate = new OutModel();

            _outFilter = new OutModel();

            _outUpdate = new OutModel();    

            _filterParams = new OrderService(_inFilterModel,_outFilter,_logger);

            _orderCreate = new OrderService(_inCreateModel,_outCreate,_logger);

            _orderUpdate = new OrderService(_inUpdateModel,_outUpdate,_logger);
 

            _filterParamsProtocol = new FilterParamsProtocol(
                _filterParams,
                _filteringValidator
                );

            _creationProtocol = new CreatingProtocol(
                _orderCreate,
                _creatingValidator
                );

            _updateProtocol = new UpdatingProtocol(
                _orderUpdate,
                _updateValidator,
                _filterParams
                );

            _userProtocol = new UserProtocol(
               _filterParamsProtocol,
               _updateProtocol,
               _creationProtocol
               );
            _userProtocol.StartInteraction();
        }
    }
}
