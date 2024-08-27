using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using RentalProject.Repositories.Implementation;
using RentalProject.Repositories.Infrastructure;
using RentRide.Models.ViewModels.Vehicle;

namespace RentRide.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly IVehicleRepository _vehicleRepository;
        private IMapper _mapper;


        public VehiclesController(IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int pageNumber=1, int pageSize=10,string SearchingText=null)
        {
            IEnumerable<VehicleViewModel> viewModelList;
            var vehicles =  _vehicleRepository.GetVehicles().GetAwaiter().GetResult().Skip((pageNumber*pageSize)-pageSize).Take(pageSize);
            var viewModel = _mapper.Map<IEnumerable<VehicleViewModel>>(vehicles);
           
            if (!String.IsNullOrEmpty(SearchingText))
            {
                viewModel = viewModel.Where(x => x.VehicleNumber.Equals(SearchingText, StringComparison.OrdinalIgnoreCase));
            }
            var VehicleViewModel = new ListVehicleViewModel
            {
                VehicleList = viewModel,
                PageInfo = new Utilities.PageInfo
                {
                    ItemsPerPage = pageSize,
                    CurrentPage = pageNumber,
                    TotalItems = _vehicleRepository.GetVehicles().GetAwaiter().GetResult().Count()
                }
            };
           
            return View(vehicles);
            
        }
    }
}
