using LoandLoanAproveBankCustomer.Model;
using LoandLoanAproveBankCustomer.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoandLoanAproveBankCustomer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;  
        private readonly IBankRepository _bankRepository;   
        public CustomerController(ICustomerRepository customerRepository,IBankRepository bankRepository)
        {
            _customerRepository = customerRepository;
            _bankRepository = bankRepository;   
        }
        
        [HttpPut("/Transaction ")]
        public async Task<IActionResult> Tansaction(int cId, double balance,string transactionType)
        {
            var result=await _customerRepository.Trnsaction(cId, balance,transactionType);  
            if(result==-3)
            {
                return StatusCode(500, "Your account Balance not enough.....!");
            }
            else if(result==-4)
            {
                return StatusCode(200, "Your account balace is not enough...but your transaction is complited by creadit");
            }
            return StatusCode(200,"Transaction Successfull....!");

        }
        [HttpPost]
        public async Task<IActionResult> AddNewCustomer(Customer customer)
        {
            var result = await _customerRepository.AddNewCustomer(customer);
            if(result==null)
            {
                return StatusCode(400, "Someting is wrong");

            }
            else 
            {
                return StatusCode(200, "Account is opening is done !...");
            }
        }
       
    }
}
